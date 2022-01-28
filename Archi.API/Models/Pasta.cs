using Archi.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archi.API.Models
{
    public class Pasta : BaseModel
    {
        public string Name { get; set; }
        public string Salsa { get; set; }
        public decimal Price { get; set; }
    }
}
