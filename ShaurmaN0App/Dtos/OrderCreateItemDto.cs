using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ShaurmaN0App.Dtos
{
    public class OrderCreateItemDto
    {
        [Required]
        [NotNull]
        public Guid MenusId { get; set; }
        [Range(1, 20)]
        public int Count { get; set; }
    }
}