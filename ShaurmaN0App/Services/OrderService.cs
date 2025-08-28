using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;
using ShaurmaN0App.Services.Base;

namespace ShaurmaN0App.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await orderRepository.GetAllAsync();
        }

        public Task<Order> CreateAsync(Order order)
        {
            return orderRepository.CreateAsync(order);
        }
    }
}