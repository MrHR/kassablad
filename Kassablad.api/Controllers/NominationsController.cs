using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Kassablad.api.Models;
using Kassablad.api.Data;

namespace Kassablad.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class NominationController : ControllerBase
    {
        private readonly KassabladContext _context;

        public NominationController(KassabladContext context)
        {
            _context = context;
        }

        // GET: api/nominations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nominations>>> GetNominations()
        {
            return await _context.Nominations.ToListAsync();
        }

        // GET: api/Nomination/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nominations>> GetNomination(int id)
        {
            var Nomination = await _context.Nominations.FindAsync(id);

            if (Nomination == null)
            {
                return NotFound();
            }

            return Nomination;
        }

        // GET: api/beginnominations/beginning
        [HttpGet("{type}")]
        public async Task<ActionResult<IEnumerable<KassaNomination>>> GetNominations(string type)
        {
            var objKassa = await _context.KassaContainer
                .Join(_context.Kassa,
                    container => container.Id,
                    kassa => kassa.KassaContainerId,
                    (container, kassa) => new { Container = container, Kassa = kassa})
                .LastAsync();
            return await _context.KassaNomination.Where(x => x.KassaId == objKassa.Kassa.Id).ToListAsync();
        }

        // PUT: api/Nomination/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomination(int id, Nominations nomination)
        {
            if (id != nomination.Id)
            {
                return BadRequest();
            }

            _context.Entry(nomination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NominationExists(id))
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

        // POST: api/Nomination
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Nominations>> PostNomination([FromForm]Nominations nomination)
        {
            nomination.Active = true;
            nomination.DateAdded = DateTime.UtcNow;
            nomination.DateUpdated = DateTime.UtcNow;
            nomination.UpdatedBy = 1; //TODO: chaneg user Id's in future to user
            nomination.CreatedBy = 1;//TODO: chaneg user Id's in future to user

            _context.Nominations.Add(nomination);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNomination", new { id = nomination.Id }, nomination);
        }

        // DELETE: api/Nomination/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nominations>> DeleteNomination(int id)
        {
            var nomination = await _context.Nominations.FindAsync(id);
            if (nomination == null)
            {
                return NotFound();
            }

            _context.Nominations.Remove(nomination);
            await _context.SaveChangesAsync();

            return nomination;
        }

        private bool NominationExists(int id)
        {
            return _context.Nominations.Any(e => e.Id == id);
        }
    }
}
