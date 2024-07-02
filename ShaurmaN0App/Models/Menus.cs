using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShaurmaN0App.Models
{
    public class Menus
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public Guid? MenusCategoryId { get; set; }
        public MenusCategory? MenusCategory { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(1, 1_000_000)]
        public double? Price{ get; set; }
    }
}