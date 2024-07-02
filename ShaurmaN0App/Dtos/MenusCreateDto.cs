using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShaurmaN0App.Dtos
{
    public class MenusCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 1_000_000)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public Guid SelectedCategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }  = new List<SelectListItem>();
    }
}