using System;
using System.Collections.Generic;
using System.Text;

namespace Archi.Lib.Models.Partial
{
    public class Partial
    {
        public string Fields { get; set; }

        public bool HasFieals()
        {
            return !string.IsNullOrWhiteSpace(Fields);
        }
    }
}
