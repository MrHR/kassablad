using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kassablad.api.Models;
using Kassablad.api.Data;

namespace Kassablad.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KassaController : ControllerBase
    {
        private readonly KassabladContext _context;

        public KassaController(KassabladContext context)
        {
            _context = context;
        }

        // GET: api/Kassa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kassa>>> GetKassa()
        {
            return await _context.Kassa.ToListAsync();
        }

        // GET: api/Kassa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kassa>> GetKassa(int id)
        {
            var kassa = await _context.Kassa.FindAsync(id);

            if (kassa == null)
            {
                return NotFound();
            }

            return kassa;
        }

        // PUT: api/Kassa/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKassa(int id, Kassa kassa)
        {
            if (id != kassa.Id)
            {
                return BadRequest();
            }

            _context.Entry(kassa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KassaExists(id))
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

        // POST: api/Kassa
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Kassa>> PostKassa(Kassa kassa)
        {
            _context.Kassa.Add(kassa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKassa", new { id = kassa.Id }, kassa);
        }

        // DELETE: api/Kassa/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kassa>> DeleteKassa(int id)
        {
            var kassa = await _context.Kassa.FindAsync(id);
            if (kassa == null)
            {
                return NotFound();
            }

            _context.Kassa.Remove(kassa);
            await _context.SaveChangesAsync();

            return kassa;
        }

        private bool KassaExists(int id)
        {
            return _context.Kassa.Any(e => e.Id == id);
        }
    }
}
