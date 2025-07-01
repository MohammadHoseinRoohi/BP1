using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice1.Entities.Base
{
    public abstract class Thing
    {
        public int Id { get; set; }
        public  DateOnly? Date { get; set; }
    }
}