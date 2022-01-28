using Archi.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archi.API.Models
{
    public class Pizza : BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Topping { get; set; }
    }
}
