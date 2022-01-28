using Archi.API.Controllers;
using Archi.API.Models;
using Archi.Lib.Models.DataFilter;
using Archi.Lib.Models.Pagination;
using Archi.Lib.Models.Params;
using Archi.Lib.Models.Partial;
using Archi.Library.Models;
using ArchiTest.data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTest
{
    public class ProductsControllerTest
    {

        private ProductsController _controller;
        private MockDbContext _context;

        [SetUp]
        public void Setup()
        {
            _context = MockDbContext.GetDbContext();
            _controller = new ProductsController(_context);
        }

        [Test]
        public async Task TestGetAll()
        {
            var actionResult = await _controller.GetAll(new Pagination(), new Params(), new Partial());
            var values = actionResult.Value as IEnumerable<Products>;

            Assert.IsNotNull(values);
            Assert.AreEqual(_context.Products.Count(), values.Count());
        }

        [Test]
        public void TestSearch()
        {

        }
        [Test]
        public void PostTest()
        {
            _controller.Product1();
            Assert.Pass();
        }
    }
}