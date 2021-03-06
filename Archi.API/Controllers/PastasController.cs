using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Archi.API.Data;
using Archi.API.Models;
using Archi.Lib.Controller;

namespace Archi.API.Controllers
{
 
    public class PastasController : BaseController<ArchiDbContext, Pasta>
    {
        public PastasController(ArchiDbContext context) : base(context)
        {

        }
    }
}
