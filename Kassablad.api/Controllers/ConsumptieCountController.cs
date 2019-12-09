using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kassablad.api.Data;
using Kassablad.api.Models;

namespace Kassablad.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptieCountController : ControllerBase
    {
        private readonly KassabladContext _context;

        public ConsumptieCountController(KassabladContext context)
        {
            _context = context;
        }

        // GET: api/ConsumptieCount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumptieCount>>> GetConsumptieCount()
        {
            return await _context.ConsumptieCount.ToListAsync();
        }

        // GET: api/ConsumptieCount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumptieCount>> GetConsumptieCount(int id)
        {
            var consumptieCount = await _context.ConsumptieCount.FindAsync(id);

            if (consumptieCount == null)
            {
                return NotFound();
            }

            return consumptieCount;
        }

        // PUT: api/ConsumptieCount/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumptieCount(int id, ConsumptieCount consumptieCount)
        {
            if (id != consumptieCount.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumptieCount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumptieCountExists(id))
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

        // POST: api/ConsumptieCount
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ConsumptieCount>> PostConsumptieCount(ConsumptieCount consumptieCount)
        {
            _context.ConsumptieCount.Add(consumptieCount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumptieCount", new { id = consumptieCount.Id }, consumptieCount);
        }

        // DELETE: api/ConsumptieCount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConsumptieCount>> DeleteConsumptieCount(int id)
        {
            var consumptieCount = await _context.ConsumptieCount.FindAsync(id);
            if (consumptieCount == null)
            {
                return NotFound();
            }

            _context.ConsumptieCount.Remove(consumptieCount);
            await _context.SaveChangesAsync();

            return consumptieCount;
        }

        private bool ConsumptieCountExists(int id)
        {
            return _context.ConsumptieCount.Any(e => e.Id == id);
        }
    }
}
