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
            return await GetKassaContainerObjectQuery().OrderByDescending(x => x.BeginUur).ToListAsync();
        }

        // GET: api/KassaContainer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjKassaContainer>> GetKassaContainer(int id)
        {
            var kassaContainer = await GetKassaContainerObjectQuery(id).FirstOrDefaultAsync();
            

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
        public IQueryable<ObjKassaContainer> GetKassaContainerObjectQuery(int id = 0) 
        {
            var objKassaContainerQuery = from kc in _context.KassaContainer
                from bk in _context.Kassa 
                from ek in _context.Kassa
                where (id == 0 || (id != 0 && kc.Id == id))
                    && bk.KassaContainerId == kc.Id 
                    && bk.Type == "begin"
                    && ek.KassaContainerId == kc.Id
                    && ek.Type == "end"
                select new ObjKassaContainer {
                    Id = kc.Id,
                    Active = kc.Active,
                    Afroomkluis = kc.Afroomkluis,
                    BeginUur = kc.BeginUur,
                    EindUur = kc.EindUur,
                    Bezoekers = kc.Bezoekers,
                    CreatedBy = kc.CreatedBy,
                    DateAdded = kc.DateAdded,
                    DateUpdated = kc.DateUpdated,
                    InkomstBar = kc.InkomstBar,
                    InkomstLidkaart = kc.InkomstLidkaart,
                    NaamTapper = kc.NaamTapper,
                    NaamTapperSluit = kc.NaamTapperSluit,
                    Notes = kc.Notes,
                    UpdatedBy = kc.UpdatedBy,
                    BeginKassa = new ObjKassa {
                        Active = bk.Active,
                        Id = bk.Id,
                        CreatedBy = bk.CreatedBy,
                        DateAdded = bk.DateAdded,
                        DateUpdated = bk.DateUpdated,
                        KassaContainerId = bk.KassaContainerId,
                        Type = bk.Type,
                        UpdatedBy = bk.UpdatedBy,
                        NominationList = (from kn in _context.KassaNomination
                            from n in _context.Nominations
                            where kn.KassaId == bk.Id && n.Id == kn.NominationId
                            select new ObjNomination {
                                Id = kn.Id,
                                NominationId = kn.NominationId,
                                Amount = kn.Amount,
                                KassaId = kn.KassaId,
                                Nomination = n
                            }).OrderBy(x => x.Nomination.Id).ToList()
                    },
                    EindKassa = new ObjKassa {
                        Active = ek.Active,
                        Id = ek.Id,
                        CreatedBy = ek.CreatedBy,
                        DateAdded = ek.DateAdded,
                        DateUpdated = ek.DateUpdated,
                        KassaContainerId = ek.KassaContainerId,
                        Type = ek.Type,
                        UpdatedBy = ek.UpdatedBy,
                        NominationList = (from kn in _context.KassaNomination
                            from n in _context.Nominations
                            where kn.KassaId == ek.Id && n.Id == kn.NominationId
                            select new ObjNomination {
                                Id = kn.Id,
                                NominationId = kn.NominationId,
                                Amount = kn.Amount,
                                KassaId = kn.KassaId,
                                Nomination = n
                            }).ToList()
                    }
                };

            return objKassaContainerQuery;
        }

        //TODO: Check if I can seperate out the long query in GetKassaContainerObjectQuery(Not working)
        public IQueryable<ObjNomination> GetKassaNominationsQuery(int id = 0) 
        {
            var objKassaNominationsQuery = from kn in _context.KassaNomination
                from n in _context.Nominations
                where kn.KassaId == id && n.Id == kn.NominationId
                select new ObjNomination {
                    Id = kn.Id,
                    Nomination = n
                };

            return objKassaNominationsQuery;
        }

        public class ObjKassaContainer : KassaContainer {
            public ObjKassa BeginKassa { get; set; }
            public ObjKassa EindKassa { get; set; }
        }

        public class ObjKassa : Kassa {
            public List<ObjNomination> NominationList { get; set; }
        }

        public class ObjNomination : KassaNomination { 
            public Nominations Nomination { get; set; }
        }
    }
}
