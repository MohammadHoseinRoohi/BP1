using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice1.Entities.Base;

namespace Practice1.Entities
{
    public class Book : Thing
    {
        public required string Title { get; set; }
        public string? Writer { get; set; }
        public string? Publisher { get; set; }
        public double Price  { get; set; }
    }
}