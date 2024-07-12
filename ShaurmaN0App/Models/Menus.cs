using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShaurmaN0App.Models
{
    public class Menus
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? MenusCategoryId { get; set; }
        public MenusCategory? MenusCategory { get; set; }
        public double? Price{ get; set; }
    }
}