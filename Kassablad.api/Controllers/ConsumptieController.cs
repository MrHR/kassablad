using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Kassablad.api.Data;
using Kassablad.api.Models;

namespace Kassablad.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class ConsumptieController : ControllerBase
    {
        private readonly KassabladContext _context;

        public ConsumptieController(KassabladContext context)
        {
            _context = context;
        }

        // GET: api/Consumptie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consumptie>>> GetConsumptie()
        {
            return await _context.Consumptie.ToListAsync();
        }

        // GET: api/Consumptie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consumptie>> GetConsumptie(int id)
        {
            var consumptie = await _context.Consumptie.FindAsync(id);

            if (consumptie == null)
            {
                return NotFound();
            }

            return consumptie;
        }

        // PUT: api/Consumptie/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumptie(int id, Consumptie consumptie)
        {
            if (id != consumptie.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumptie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumptieExists(id))
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

        // POST: api/Consumptie
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Consumptie>> PostConsumptie(Consumptie consumptie)
        {
            _context.Consumptie.Add(consumptie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumptie", new { id = consumptie.Id }, consumptie);
        }

        // DELETE: api/Consumptie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Consumptie>> DeleteConsumptie(int id)
        {
            var consumptie = await _context.Consumptie.FindAsync(id);
            if (consumptie == null)
            {
                return NotFound();
            }

            _context.Consumptie.Remove(consumptie);
            await _context.SaveChangesAsync();

            return consumptie;
        }

        private bool ConsumptieExists(int id)
        {
            return _context.Consumptie.Any(e => e.Id == id);
        }
    }
}
