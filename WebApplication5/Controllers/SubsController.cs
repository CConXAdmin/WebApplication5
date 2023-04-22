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
    public class SubsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Subs.Include(s => s.Base);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Subs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subs == null)
            {
                return NotFound();
            }

            var sub = await _context.Subs
                .Include(s => s.Base)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sub == null)
            {
                return NotFound();
            }

            return View(sub);
        }

        // GET: Subs/Create
        public IActionResult Create()
        {
            ViewData["BaseId"] = new SelectList(_context.Bases, "Id", "Id");
            return View();
        }

        // POST: Subs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name1,Name2,BaseId")] Sub sub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BaseId"] = new SelectList(_context.Bases, "Id", "Id", sub.BaseId);
            return View(sub);
        }

        // GET: Subs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subs == null)
            {
                return NotFound();
            }

            var sub = await _context.Subs.FindAsync(id);
            if (sub == null)
            {
                return NotFound();
            }
            ViewData["BaseId"] = new SelectList(_context.Bases, "Id", "Id", sub.BaseId);
            return View(sub);
        }

        // POST: Subs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name1,Name2,BaseId")] Sub sub)
        {
            if (id != sub.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubExists(sub.Id))
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
            ViewData["BaseId"] = new SelectList(_context.Bases, "Id", "Id", sub.BaseId);
            return View(sub);
        }

        // GET: Subs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subs == null)
            {
                return NotFound();
            }

            var sub = await _context.Subs
                .Include(s => s.Base)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sub == null)
            {
                return NotFound();
            }

            return View(sub);
        }

        // POST: Subs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Subs'  is null.");
            }
            var sub = await _context.Subs.FindAsync(id);
            if (sub != null)
            {
                _context.Subs.Remove(sub);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubExists(int id)
        {
          return (_context.Subs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
