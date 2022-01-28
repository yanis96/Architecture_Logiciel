using Archi.Lib.Context;
using Archi.Lib.Extensions;
using Archi.Lib.Models;
using Archi.Lib.Models.DataFilter;
using Archi.Lib.Models.Pagination;
using Archi.Lib.Models.Params;
using Archi.Lib.Models.Partial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Archi.Lib.Controller
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BaseController<TContext, TModel> : ControllerBase where TContext : BaseDbContext where TModel : BaseModel
    {
        protected readonly TContext _context;

        public BaseController(TContext context)
        {
            _context = context;
        }

        // GET: api/[Controller]
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAll([FromQuery] Pagination page, [FromQuery] Params param, [FromQuery] Partial champs)
        {
            //Pagination
            var pagination = new Pagination(page.per_page, page.current_page);
            var resultOrd = _context.Set<TModel>().Sort(param);
            
            var query = resultOrd
                                .Skip((pagination.current_page - 1) * pagination.per_page)
                                .Take(pagination.per_page);
           

            
            

                /*Filtre
            var test = this.Request.Query;

            var lambda1 = QueryExtention.FilterReserch<TModel>(test);
            var resultFiltre = query.Where(lambda1);*/

            //Réponse partièlle
            var lambda2 = QueryExtention.PartialReserch<TModel>(champs);

            if(lambda2 != null)
            {
                var result2 = query.Select(lambda2);
                return await result2.ToListAsync();
            }

            return await query.ToListAsync();
        }



        [HttpGet("search")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TModel>>> Search()
        {
            var test = this.Request.Query;

            IQueryable<TModel> query = _context.Set<TModel>();

            var lambda = QueryExtention.SearchExpression<TModel>(test);

            query = query.Where(lambda);

            return await query.ToListAsync();
        }



        // GET: api/[Controllers]/5
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<ActionResult<TModel>> GetItem(int id)
        {
            var item = await _context.Set<TModel>().FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/[Controller]/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<IActionResult> PutItem(int id, TModel model)
        {
            if (id != model.ID)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/[Controller]
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<ActionResult<TModel>> PostItem(TModel item)
        {
            _context.Set<TModel>().Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.ID }, item);
        }

        // DELETE: api/[Controller]/5
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<ActionResult<TModel>> DeleteItem(int id)
        {
            var item = await _context.Set<TModel>().FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Set<TModel>().Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        private bool ModelExists(int id)
        {
            return _context.Set<TModel>().Any(e => e.ID == id);
        }
    }
}
