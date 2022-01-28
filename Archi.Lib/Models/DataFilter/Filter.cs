using System;
using System.Collections.Generic;
using System.Text;

namespace Archi.Lib.Models.DataFilter
{
    public class Filter
    {
        public string Conditions { get; set; }
        public bool HasConditions()
        {
            return !string.IsNullOrWhiteSpace(Conditions);
        }
    }
}
