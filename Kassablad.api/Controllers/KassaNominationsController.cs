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
    public class KassaNominationsController : ControllerBase
    {
        private readonly KassabladContext _context;

        public KassaNominationsController(KassabladContext context)
        {
            _context = context;
        }

        // GET: api/KassaNominations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KassaNomination>>> GetKassaNomination()
        {
            return await _context.KassaNomination.ToListAsync();
        }

        // GET: api/KassaNominations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KassaNomination>> GetKassaNomination(int id)
        {
            var kassaNomination = await _context.KassaNomination.FindAsync(id);

            if (kassaNomination == null)
            {
                return NotFound();
            }

            return kassaNomination;
        }

        // PUT: api/KassaNominations/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKassaNomination(int id, KassaNomination kassaNomination)
        {
            if (id != kassaNomination.Id)
            {
                return BadRequest();
            }

            _context.Entry(kassaNomination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KassaNominationExists(id))
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

        // POST: api/KassaNominations
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<KassaNomination>> PostKassaNomination(KassaNomination kassaNomination)
        {
            kassaNomination.Active = true;
            kassaNomination.DateAdded = DateTime.Now;
            kassaNomination.DateUpdated = DateTime.Now;
            kassaNomination.CreatedBy = 1; //TODO: swap 1 for UserId
            kassaNomination.UpdatedBy = 1;

            _context.KassaNomination.Add(kassaNomination);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKassaNomination", new { id = kassaNomination.Id }, kassaNomination);
        }

        // DELETE: api/KassaNominations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KassaNomination>> DeleteKassaNomination(int id)
        {
            var kassaNomination = await _context.KassaNomination.FindAsync(id);
            if (kassaNomination == null)
            {
                return NotFound();
            }

            _context.KassaNomination.Remove(kassaNomination);
            await _context.SaveChangesAsync();

            return kassaNomination;
        }

        private bool KassaNominationExists(int id)
        {
            return _context.KassaNomination.Any(e => e.Id == id);
        }
    }
}
