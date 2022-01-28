using Archi.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archi.API.Models
{
    public class Burger : BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Composition { get; set; }
    }
}
