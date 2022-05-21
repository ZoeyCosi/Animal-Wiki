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
    public class AnimalClassesController : Controller
    {
        private readonly AnimalContext _context;

        public AnimalClassesController(AnimalContext context)
        {
            _context = context;
        }

        // GET: AnimalClasses
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                var animalContext = _context.classes.Include(p => p.Phylium);
                return View(await animalContext.ToListAsync());
            }
            else
            {
                var animalContext = _context.classes.Where(e => e.PhyliumID == id).Include(p => p.Phylium);
                return View(await animalContext.ToListAsync());
            }
        }

        // GET: AnimalClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalClass = await _context.classes
                .Include(a => a.Phylium)
                .FirstOrDefaultAsync(m => m.id == id);
            if (animalClass == null)
            {
                return NotFound();
            }

            return View(animalClass);
        }

        // GET: AnimalClasses/Create
        public IActionResult Create()
        {
            ViewData["PhyliumID"] = new SelectList(_context.phylia, "id", "name");
            return View();
        }

        // POST: AnimalClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,photopath,PhyliumID")] AnimalClass animalClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animalClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhyliumID"] = new SelectList(_context.phylia, "id", "id", animalClass.PhyliumID);
            return View(animalClass);
        }

        // GET: AnimalClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalClass = await _context.classes.FindAsync(id);
            if (animalClass == null)
            {
                return NotFound();
            }
            ViewData["PhyliumID"] = new SelectList(_context.phylia, "id", "id", animalClass.PhyliumID);
            return View(animalClass);
        }

        // POST: AnimalClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,photopath,PhyliumID")] AnimalClass animalClass)
        {
            if (id != animalClass.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalClassExists(animalClass.id))
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
            ViewData["PhyliumID"] = new SelectList(_context.phylia, "id", "id", animalClass.PhyliumID);
            return View(animalClass);
        }

        // GET: AnimalClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalClass = await _context.classes
                .Include(a => a.Phylium)
                .FirstOrDefaultAsync(m => m.id == id);
            if (animalClass == null)
            {
                return NotFound();
            }

            return View(animalClass);
        }

        // POST: AnimalClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalClass = await _context.classes.FindAsync(id);
            _context.classes.Remove(animalClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalClassExists(int id)
        {
            return _context.classes.Any(e => e.id == id);
        }
    }
}
