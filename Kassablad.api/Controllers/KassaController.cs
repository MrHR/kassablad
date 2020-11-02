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
    public class KassaController : ControllerBase
    {
        private readonly KassabladContext _context;

        public KassaController(KassabladContext context)
        {
            _context = context;
        }

        // GET: api/Kassa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KassaItem>>> GetKassa(string startDate = "", string endDate = "")
        {
            var kassaList = new List<KassaItem>();
            var StartDate = (startDate != "" && startDate != "undefined") ? Convert.ToDateTime(startDate) : DateTime.Now.AddMonths(-4);
            var EndDate = (endDate != "" && endDate != "undefined") ? Convert.ToDateTime(endDate) : DateTime.Now;
            
            kassaList = await _context.Kassa
                .Join(_context.KassaContainer,
                    kassa => kassa.KassaContainerId,
                    container => container.Id,
                    (kassa, container) => new { Kassa = kassa, Container = container }
                ).Where(
                    x => StartDate == null || (StartDate != null && x.Container.BeginUur >= StartDate) 
                    && EndDate == null || (EndDate != null && x.Container.BeginUur <= EndDate)
                ).Select(x => new KassaItem {
                    CreatedBy = x.Kassa.CreatedBy,
                    DateAdded = x.Kassa.DateAdded,
                    DateUpdated = x.Kassa.DateUpdated,
                    KassaContainerId = x.Kassa.KassaContainerId,
                    Type = x.Kassa.Type,
                    Id = x.Kassa.Id,
                    Active = x.Kassa.Active,
                    UpdatedBy = x.Kassa.UpdatedBy,
                    NaamTapper = x.Container.NaamTapper,
                    NaamTapperSluit = x.Container.NaamTapperSluit,
                    BeginUur = x.Container.BeginUur,
                    EindUur = x.Container.EindUur
                }).ToListAsync();

            return kassaList;
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
            kassa.Active = true;
            kassa.DateAdded = DateTime.UtcNow;
            kassa.DateUpdated = DateTime.UtcNow;
            kassa.UpdatedBy = 1; //TODO: chaneg user Id's in future to user
            kassa.CreatedBy = 1;//TODO: chaneg user Id's in future to user

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

        public class KassaItem {
            public int Id { get; set; }
            public bool Active { get; set; }
            public int CreatedBy { get; set; }
            public DateTime DateAdded { get; set; }
            public DateTime DateUpdated { get; set; }
            public int KassaContainerId { get; set; }
            public string Type { get; set; }
            public int UpdatedBy { get; set; }
            public string UserName { get; set; }
            public string NaamTapper { get; set; }
            public string Activity { get; set; }
            public string NaamTapperSluit { get; set; }
            public DateTime BeginUur { get; set; }
            public DateTime EindUur { get; set; }
        }
    }
}
