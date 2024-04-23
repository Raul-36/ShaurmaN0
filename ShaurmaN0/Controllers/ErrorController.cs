namespace ShaurmaN0.Controllers;

using System.Net;
using ShaurmaN0.Attributes.Http;
using ShaurmaN0.Controllers.Base;

public class ErrorController : ControllerBase
{
    [HttpGet]
    public async Task NotFound(string? resourceName) {
        Dictionary<string, object>? viewValues = new() {
            {"resource", resourceName ?? "/"}
        };

        await WriteViewAsync("notfound", viewValues);

        base.Response.StatusCode = (int)HttpStatusCode.NotFound;
    }
}