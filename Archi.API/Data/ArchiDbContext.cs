using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archi.API.Models;
using Archi.Lib.Context;

namespace Archi.API.Data
{
    public class ArchiDbContext : BaseDbContext
    {
        public ArchiDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<Archi.API.Models.Burger> Burger { get; set; }
        public DbSet<Archi.API.Models.Customer> Customer { get; set; }
        public DbSet<Archi.API.Models.Drinks> Drinks { get; set; }
        public DbSet<Archi.API.Models.Pasta> Pasta { get; set; }
        public DbSet<Archi.API.Models.Pizza> Pizza { get; set; }
        public DbSet<Archi.API.Models.Products> Products { get; set; }
        
    }
}
