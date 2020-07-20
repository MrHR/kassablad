using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kassablad.api.Data;
using Kassablad.api.Models;

namespace Kassablad.api.Controllers
{
    public class KassaTemplateController : Controller
    {
        private readonly KassabladContext _context;

        public KassaTemplateController(KassabladContext context)
        {
            _context = context;
        }

        // GET: KassaTemplate
        public async Task<IActionResult> Index()
        {
            return View(await _context.KassaTemplate.ToListAsync());
        }

        // GET: KassaTemplate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kassaTemplate = await _context.KassaTemplate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kassaTemplate == null)
            {
                return NotFound();
            }

            return View(kassaTemplate);
        }

        // GET: KassaTemplate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KassaTemplate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Active,DateAdded,DateUpdated,UpdatedBy,CreatedBy,Nominations")] KassaTemplate kassaTemplate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kassaTemplate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kassaTemplate);
        }

        // GET: KassaTemplate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kassaTemplate = await _context.KassaTemplate.FindAsync(id);
            if (kassaTemplate == null)
            {
                return NotFound();
            }
            return View(kassaTemplate);
        }

        // POST: KassaTemplate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Active,DateAdded,DateUpdated,UpdatedBy,CreatedBy,Nominations")] KassaTemplate kassaTemplate)
        {
            if (id != kassaTemplate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kassaTemplate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KassaTemplateExists(kassaTemplate.Id))
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
            return View(kassaTemplate);
        }

        // GET: KassaTemplate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kassaTemplate = await _context.KassaTemplate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kassaTemplate == null)
            {
                return NotFound();
            }

            return View(kassaTemplate);
        }

        // POST: KassaTemplate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kassaTemplate = await _context.KassaTemplate.FindAsync(id);
            _context.KassaTemplate.Remove(kassaTemplate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KassaTemplateExists(int id)
        {
            return _context.KassaTemplate.Any(e => e.Id == id);
        }
    }
}
