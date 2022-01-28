using Archi.API.Data;
using Archi.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiTest.data
{
    public class MockDbContext : ArchiDbContext
    {
        public MockDbContext(DbContextOptions options) : base(options)
        {
        }

        public static MockDbContext GetDbContext(bool withData = true)
        {
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase("dbtest").Options;
            var db = new MockDbContext(options);

            if (withData)
            {
                db.Burger.Add(new Burger { Name = "Burger 2", Price = 4, Composition = "Salade, Steak" });
                db.Burger.Add(new Burger { Name = "Burger 3", Price = 3, Composition = "Tomate, Fromage" });
                db.SaveChanges();
            }
            return db;
        }
    }
}