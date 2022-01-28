using System;
using System.Collections.Generic;
using System.Text;

namespace Archi.Lib.Models.Params
{
    public class Params
    {
        public string Asc { get; set; }
        public string Desc { get; set; }

        public bool HasAscOrder()
        {
            return !string.IsNullOrWhiteSpace(Asc);
        }
        public bool HasDescOrder()
        {
            return !string.IsNullOrWhiteSpace(Desc);
        }
    }
}
