using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShaurmaN0App.Dtos
{
    public class OrderCreateDto
    {
        public IEnumerable<OrderCreateItemDto> OrderItems { get; set; } = new List<OrderCreateItemDto>();
    }
}