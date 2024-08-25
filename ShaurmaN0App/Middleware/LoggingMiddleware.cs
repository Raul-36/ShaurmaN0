using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ShaurmaN0App.Models;

namespace ShaurmaN0App.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public LoggingMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("SqlDb");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            bool LoggingEnabled = this.configuration.GetValue<bool>("Logging:Enabled");
            if (!LoggingEnabled)
            {
                await this.next(context);
                return;
            }

            var log = new Log
            {
                Url = context.Request.Path,
                HttpMethod = context.Request.Method,
                CreationDate = DateTime.UtcNow
            };

            context.Request.EnableBuffering();
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                log.RequestBody = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
            }

            var originalResponseBodyStream = context.Response.Body;
            using (var responseBodyStream = new MemoryStream())
            {
                context.Response.Body = responseBodyStream;

                await this.next(context);
                context.Response.Body = originalResponseBodyStream;
                responseBodyStream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(responseBodyStream))
                {
                    log.ResponseBody = await reader.ReadToEndAsync();
                    responseBodyStream.Seek(0, SeekOrigin.Begin);
                    await responseBodyStream.CopyToAsync(originalResponseBodyStream);
                }
            }
            log.StatusCode = context.Response.StatusCode;
            log.EndDate = DateTime.UtcNow;
            Console.WriteLine(log.EndDate);
            await LogRequestAsync(log);
        }

        private async Task LogRequestAsync(Log log)
        {
            var connection = new SqlConnection(this.connectionString);
            var sql = @"
                    insert into Log (Url, RequestBody, ResponseBody, CreationDate, EndDate, StatusCode, HttpMethod)
                    values (@Url, @RequestBody, @ResponseBody, @CreationDate, @EndDate, @StatusCode, @HttpMethod)";
            await connection.ExecuteAsync(sql, log);
        }
    }
}