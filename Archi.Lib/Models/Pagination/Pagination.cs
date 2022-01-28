using System;
using System.Collections.Generic;
using System.Text;

namespace Archi.Lib.Models.Pagination
{
    public class Pagination
    {
        public int per_page { get; set; }
        public int current_page { get; set; }

        public Pagination()
        {
            this.per_page = 3;
            this.current_page = 1;
        }

        public Pagination(int per_page, int current_page)
        {
            this.per_page = per_page > 5 ? 5 : per_page;
            this.current_page = current_page < 1 ? 1 : current_page;
        }
    }
}
