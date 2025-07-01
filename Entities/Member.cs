using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice1.Entities.Base;
using Practice1.Enums;

namespace Practice1.Entities
{
    public class Member : Thing
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public Gender Gender { get; set; }
    }
}