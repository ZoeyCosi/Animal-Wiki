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
    public class SpeciesController : Controller
    {
        private readonly AnimalContext _context;

        public SpeciesController(AnimalContext context)
        {
            _context = context;
        }

        // GET: Species
        public async Task<IActionResult> Index(int? id)
        {
            ViewData["GeniusID"] = new SelectList(_context.genius, "id", "name");
            if (id == null)
            {
                var animalContext = _context.species.Include(p => p.Genius);
                return View(await animalContext.ToListAsync());
            }
            else
            {

                var animalContext = _context.species.Where(e => e.GeniusID == id).Include(p => p.Genius);
                return View(await animalContext.ToListAsync());
            }
        }

        // GET: Species/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["GeniusID"] = new SelectList(_context.genius, "id", "name");
            if (id == null)
            {
                return NotFound();
            }

            var species = await _context.species
                .Include(s => s.Genius)
                .FirstOrDefaultAsync(m => m.id == id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // GET: Species/Create
        public IActionResult Create()
        {
            ViewData["GeniusID"] = new SelectList(_context.genius, "id", "name");
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,photopath,scientificname,GeniusID")] Species species)
        {
            if (ModelState.IsValid)
            {
                _context.Add(species);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeniusID"] = new SelectList(_context.genius, "id", "id", species.GeniusID);
            return View(species);
        }

        // GET: Species/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await _context.species.FindAsync(id);
            if (species == null)
            {
                return NotFound();
            }
            ViewData["GeniusID"] = new SelectList(_context.genius, "id", "id", species.GeniusID);
            return View(species);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,photopath,scientificname,GeniusID")] Species species)
        {
            if (id != species.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(species);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeciesExists(species.id))
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
            ViewData["GeniusID"] = new SelectList(_context.genius, "id", "id", species.GeniusID);
            return View(species);
        }

        // GET: Species/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await _context.species
                .Include(s => s.Genius)
                .FirstOrDefaultAsync(m => m.id == id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var species = await _context.species.FindAsync(id);
            _context.species.Remove(species);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeciesExists(int id)
        {
            return _context.species.Any(e => e.id == id);
        }
    }
}
