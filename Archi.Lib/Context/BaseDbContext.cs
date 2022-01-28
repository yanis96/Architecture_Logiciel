using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archi.Lib.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions option) : base(option) { 
        
        }
    }
}
