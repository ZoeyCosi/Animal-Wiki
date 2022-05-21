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
    public class KingdomsController : Controller
    {
        private readonly AnimalContext _context;

        public KingdomsController(AnimalContext context)
        {
            _context = context;
        }

        // GET: Kingdoms
        public async Task<IActionResult> Index()
        {
            return View(await _context.kingdoms.ToListAsync());
        }

        // GET: Kingdoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kingdom = await _context.kingdoms
                .FirstOrDefaultAsync(m => m.id == id);
            if (kingdom == null)
            {
                return NotFound();
            }

            return View(kingdom);
        }


        //info testing
        public async Task<IActionResult> info(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kingdom = await _context.kingdoms
                .FirstOrDefaultAsync(m => m.id == id);
            if (kingdom == null)
            {
                return NotFound();
            }

            return View(kingdom);
        }





        // GET: Kingdoms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kingdoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,photopath")] Kingdom kingdom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kingdom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kingdom);
        }

        // GET: Kingdoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kingdom = await _context.kingdoms.FindAsync(id);
            if (kingdom == null)
            {
                return NotFound();
            }
            return View(kingdom);
        }

        // POST: Kingdoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,photopath")] Kingdom kingdom)
        {
            if (id != kingdom.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kingdom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KingdomExists(kingdom.id))
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
            return View(kingdom);
        }

        // GET: Kingdoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kingdom = await _context.kingdoms
                .FirstOrDefaultAsync(m => m.id == id);
            if (kingdom == null)
            {
                return NotFound();
            }

            return View(kingdom);
        }

        // POST: Kingdoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kingdom = await _context.kingdoms.FindAsync(id);
            _context.kingdoms.Remove(kingdom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KingdomExists(int id)
        {
            return _context.kingdoms.Any(e => e.id == id);
        }
    }
}
