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
    public class PhyliumsController : Controller
    {
        private readonly AnimalContext _context;

        public PhyliumsController(AnimalContext context)
        {
            _context = context;
        }

        // GET: Phyliums
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                var animalContext = _context.phylia.Include(p => p.Kingdom);
                return View(await animalContext.ToListAsync());
            }
            else
            {
                var animalContext = _context.phylia.Where(e => e.KingdomID == id).Include(p => p.Kingdom);
                return View(await animalContext.ToListAsync());
            }
        }



        // GET: Phyliums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phylium = await _context.phylia
                .Include(p => p.Kingdom)
                .FirstOrDefaultAsync(m => m.id == id);
            if (phylium == null)
            {
                return NotFound();
            }

            return View(phylium);
        }





        // GET: Phyliums/Create
        public IActionResult Create()
        {
            ViewData["KingdomID"] = new SelectList(_context.kingdoms, "id", "name");
            return View();
        }

        // POST: Phyliums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,photopath,KingdomID")] Phylium phylium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phylium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KingdomID"] = new SelectList(_context.kingdoms, "id", "id", phylium.KingdomID);
            return View(phylium);
        }

        // GET: Phyliums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phylium = await _context.phylia.FindAsync(id);
            if (phylium == null)
            {
                return NotFound();
            }
            ViewData["KingdomID"] = new SelectList(_context.kingdoms, "id", "id", phylium.KingdomID);
            return View(phylium);
        }

        // POST: Phyliums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,photopath,KingdomID")] Phylium phylium)
        {
            if (id != phylium.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phylium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhyliumExists(phylium.id))
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
            ViewData["KingdomID"] = new SelectList(_context.kingdoms, "id", "id", phylium.KingdomID);
            return View(phylium);
        }

        // GET: Phyliums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phylium = await _context.phylia
                .Include(p => p.Kingdom)
                .FirstOrDefaultAsync(m => m.id == id);
            if (phylium == null)
            {
                return NotFound();
            }

            return View(phylium);
        }

        // POST: Phyliums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phylium = await _context.phylia.FindAsync(id);
            _context.phylia.Remove(phylium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhyliumExists(int id)
        {
            return _context.phylia.Any(e => e.id == id);
        }
    }
}
