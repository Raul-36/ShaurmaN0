using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShaurmaN0.Models;

    public class PersonMenuItem
    {
     public int Id { get; set; }   
     public int? PersonId { get; set; }   
     public int? MenuItemId { get; set; }   
    }