using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class OtherSubsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OtherSubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OtherSubs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OtherSubs.Include(o => o.OtherBase);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OtherSubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OtherSubs == null)
            {
                return NotFound();
            }

            var otherSub = await _context.OtherSubs
                .Include(o => o.OtherBase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otherSub == null)
            {
                return NotFound();
            }

            return View(otherSub);
        }

        // GET: OtherSubs/Create
        public IActionResult Create()
        {
            ViewData["OtherBaseId"] = new SelectList(_context.OtherBases, "Id", "Name2");
            return View();
        }

        // POST: OtherSubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name1,Name2,OtherBaseId")] OtherSub otherSub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otherSub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OtherBaseId"] = new SelectList(_context.OtherBases, "Id", "Name2", otherSub.OtherBaseId);
            return View(otherSub);
        }

        // GET: OtherSubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OtherSubs == null)
            {
                return NotFound();
            }

            var otherSub = await _context.OtherSubs.FindAsync(id);
            if (otherSub == null)
            {
                return NotFound();
            }
            ViewData["OtherBaseId"] = new SelectList(_context.OtherBases, "Id", "Name2", otherSub.OtherBaseId);
            return View(otherSub);
        }

        // POST: OtherSubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name1,Name2,OtherBaseId")] OtherSub otherSub)
        {
            if (id != otherSub.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otherSub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtherSubExists(otherSub.Id))
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
            ViewData["OtherBaseId"] = new SelectList(_context.OtherBases, "Id", "Name2", otherSub.OtherBaseId);
            return View(otherSub);
        }

        // GET: OtherSubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OtherSubs == null)
            {
                return NotFound();
            }

            var otherSub = await _context.OtherSubs
                .Include(o => o.OtherBase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otherSub == null)
            {
                return NotFound();
            }

            return View(otherSub);
        }

        // POST: OtherSubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OtherSubs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OtherSubs'  is null.");
            }
            var otherSub = await _context.OtherSubs.FindAsync(id);
            if (otherSub != null)
            {
                _context.OtherSubs.Remove(otherSub);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtherSubExists(int id)
        {
          return (_context.OtherSubs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
