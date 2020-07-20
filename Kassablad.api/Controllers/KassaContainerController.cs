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
    public class KassaContainerController : ControllerBase
    {
        private readonly KassabladContext _context;

        public KassaContainerController(KassabladContext context)
        {
            _context = context;
        }

        // GET: api/KassaContainer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KassaContainer>>> GetKassaContainer()
        {
            return await _context.KassaContainer.ToListAsync();
        }

        // GET: api/KassaContainer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KassaContainer>> GetKassaContainer(int id)
        {
            var kassaContainer = await _context.KassaContainer.FindAsync(id);

            if (kassaContainer == null)
            {
                return NotFound();
            }

            return kassaContainer;
        }

        // PUT: api/KassaContainer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKassaContainer(int id, KassaContainer kassaContainer)
        {
            if (id != kassaContainer.Id)
            {
                return BadRequest();
            }

            _context.Entry(kassaContainer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KassaContainerExists(id))
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

        // POST: api/KassaContainer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<KassaContainer>> PostKassaContainer(KassaContainer kassaContainer)
        {
            kassaContainer.Active = true;
            kassaContainer.DateUpdated = DateTime.UtcNow;
            kassaContainer.DateAdded = DateTime.UtcNow;
            kassaContainer.UpdatedBy = 1; //TODO: chaneg user Id's in future to user
            kassaContainer.CreatedBy = 1; //TODO: chaneg user Id's in future to user
            kassaContainer.BeginUur = kassaContainer.BeginUur;
            kassaContainer.NaamTapper = kassaContainer.NaamTapper;

            _context.KassaContainer.Add(kassaContainer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKassaContainer", new { id = kassaContainer.Id }, kassaContainer);
        }

        // DELETE: api/KassaContainer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KassaContainer>> DeleteKassaContainer(int id)
        {
            var kassaContainer = await _context.KassaContainer.FindAsync(id);
            if (kassaContainer == null)
            {
                return NotFound();
            }

            _context.KassaContainer.Remove(kassaContainer);
            await _context.SaveChangesAsync();

            return kassaContainer;
        }

        private bool KassaContainerExists(int id)
        {
            return _context.KassaContainer.Any(e => e.Id == id);
        }
    }
}
