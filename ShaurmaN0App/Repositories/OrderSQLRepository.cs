using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShaurmaN0App.Data;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;

namespace ShaurmaN0App.Repositories
{
    public class OrderSQLRepository : IOrderRepository
    {

        private readonly ShaurmaDbContext context;

        public OrderSQLRepository(ShaurmaDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            if (context.Orders == null)
            {
                throw new InvalidOperationException("Orders DbSet is not initialized.");
            }
            return await context.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();
        }

        public async Task<Order> CreateAsync(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            return order;
        }

    }
}