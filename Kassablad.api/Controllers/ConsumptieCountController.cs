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

        [HttpGet]
        [Route("~/api/[controller]/container/{containerid}")]
        public async Task<ActionResult<IEnumerable<ConsumptieCount>>> GetContainerConsumptieCounts(int containerid)
        {
            return await _context.ConsumptieCount.Where(x => x.KassaContainerId == containerid).ToListAsync();
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

            consumptieCount.DateUpdated = DateTime.UtcNow;

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
            consumptieCount.Active = true;
            consumptieCount.DateAdded = DateTime.Now;
            consumptieCount.DateUpdated = DateTime.UtcNow;
            consumptieCount.CreatedBy = 1; //TODO: user user id instead
            consumptieCount.UpdatedBy = 1; //TODO: use user id instead

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
