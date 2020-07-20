using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Kassablad.api.Data;
using Kassablad.api.Models;

namespace Kassablad.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class KassaNominationsController : Controller
    {
        private readonly KassabladContext _context;

        public KassaNominationsController(KassabladContext context)
        {
            _context = context;
        }

        // GET: KassaNominations
        public async Task<IActionResult> Index()
        {
            return View(await _context.KassaNomination.ToListAsync());
        }

        // GET: KassaNominations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kassaNomination = await _context.KassaNomination
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kassaNomination == null)
            {
                return NotFound();
            }

            return View(kassaNomination);
        }

        // GET: KassaNominations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KassaNominations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Active,DateAdded,DateUpdated,UpdatedBy,CreatedBy,KassaId,NominationId,Amount")] KassaNomination kassaNomination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kassaNomination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kassaNomination);
        }

        // GET: KassaNominations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kassaNomination = await _context.KassaNomination.FindAsync(id);
            if (kassaNomination == null)
            {
                return NotFound();
            }
            return View(kassaNomination);
        }

        // POST: KassaNominations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Active,DateAdded,DateUpdated,UpdatedBy,CreatedBy,KassaId,NominationId,Amount")] KassaNomination kassaNomination)
        {
            if (id != kassaNomination.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kassaNomination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KassaNominationExists(kassaNomination.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kassaNomination);
        }

        // GET: KassaNominations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kassaNomination = await _context.KassaNomination
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kassaNomination == null)
            {
                return NotFound();
            }

            return View(kassaNomination);
        }

        // POST: KassaNominations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kassaNomination = await _context.KassaNomination.FindAsync(id);
            _context.KassaNomination.Remove(kassaNomination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KassaNominationExists(int id)
        {
            return _context.KassaNomination.Any(e => e.Id == id);
        }
    }
}
