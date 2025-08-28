using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShaurmaN0App.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DataType Date { get; set; }
        [Required(ErrorMessage = "Total is required")]
        [Range(1, 1_000_000)]
        public double Total { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}