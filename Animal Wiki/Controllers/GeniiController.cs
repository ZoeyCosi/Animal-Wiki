using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Animal_Wiki.Models;

namespace Animal_Wiki.Controllers
{
    public class GeniiController : Controller
    {
        private readonly AnimalContext _context;

        public GeniiController(AnimalContext context)
        {
            _context = context;
        }

        // GET: Genii
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                var animalContext = _context.genius.Include(p => p.Family);
                return View(await animalContext.ToListAsync());
            }
            else
            {
                var animalContext = _context.genius.Where(e => e.FamilyID == id).Include(p => p.Family);
                return View(await animalContext.ToListAsync());
            }
        }

        // GET: Genii/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genius = await _context.genius
                .Include(g => g.Family)
                .FirstOrDefaultAsync(m => m.id == id);
            if (genius == null)
            {
                return NotFound();
            }

            return View(genius);
        }

        // GET: Genii/Create
        public IActionResult Create()
        {
            ViewData["FamilyID"] = new SelectList(_context.families, "id", "name");
            return View();
        }

        // POST: Genii/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,photopath,FamilyID")] Genius genius)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genius);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FamilyID"] = new SelectList(_context.families, "id", "id", genius.FamilyID);
            return View(genius);
        }

        // GET: Genii/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genius = await _context.genius.FindAsync(id);
            if (genius == null)
            {
                return NotFound();
            }
            ViewData["FamilyID"] = new SelectList(_context.families, "id", "id", genius.FamilyID);
            return View(genius);
        }

        // POST: Genii/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,photopath,FamilyID")] Genius genius)
        {
            if (id != genius.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genius);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeniusExists(genius.id))
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
            ViewData["FamilyID"] = new SelectList(_context.families, "id", "id", genius.FamilyID);
            return View(genius);
        }

        // GET: Genii/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genius = await _context.genius
                .Include(g => g.Family)
                .FirstOrDefaultAsync(m => m.id == id);
            if (genius == null)
            {
                return NotFound();
            }

            return View(genius);
        }

        // POST: Genii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genius = await _context.genius.FindAsync(id);
            _context.genius.Remove(genius);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeniusExists(int id)
        {
            return _context.genius.Any(e => e.id == id);
        }
    }
}
