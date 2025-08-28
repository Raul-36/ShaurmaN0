using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShaurmaN0App.Models;

namespace ShaurmaN0App.Repositories.Base
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetAllAsync();
        public Task<Order> CreateAsync(Order order);
    }
}
