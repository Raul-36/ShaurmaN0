using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShaurmaN0App.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? MenusId { get; set; }
        [Required(ErrorMessage = "Total is required")]
        [Range(1, 1_000_000)]
        public double Total { get; set; }
        [Required(ErrorMessage = "Coutn is required")]
        [Range(1, 20)]
        public int Coutn { get; set; }

        public Menus? Menus { get; set; }
    }
}