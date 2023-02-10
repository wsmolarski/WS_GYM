using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WS_GYM.Data;
using WS_GYM.Models;

namespace WS_GYM.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class KarnetyController : Controller
    {
        private readonly FitnessContext _context;

        public KarnetyController(FitnessContext context)
        {
            _context = context;
        }

        // GET: Karnety
        public async Task<IActionResult> Index()
        {
              return View(await _context.Karnety.ToListAsync());
        }

        // GET: Karnety/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Karnety == null)
            {
                return NotFound();
            }

            var karnet = await _context.Karnety
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karnet == null)
            {
                return NotFound();
            }

            return View(karnet);
        }

        // GET: Karnety/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Karnety/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Start,End")] Karnet karnet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karnet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(karnet);
        }

        // GET: Karnety/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Karnety == null)
            {
                return NotFound();
            }

            var karnet = await _context.Karnety.FindAsync(id);
            if (karnet == null)
            {
                return NotFound();
            }
            return View(karnet);
        }

        // POST: Karnety/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Start,End")] Karnet karnet)
        {
            if (id != karnet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karnet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KarnetExists(karnet.Id))
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
            return View(karnet);
        }

        // GET: Karnety/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Karnety == null)
            {
                return NotFound();
            }

            var karnet = await _context.Karnety
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karnet == null)
            {
                return NotFound();
            }

            return View(karnet);
        }

        // POST: Karnety/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Karnety == null)
            {
                return Problem("Entity set 'FitnessContext.Karnety'  is null.");
            }
            var karnet = await _context.Karnety.FindAsync(id);
            if (karnet != null)
            {
                _context.Karnety.Remove(karnet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KarnetExists(int id)
        {
          return _context.Karnety.Any(e => e.Id == id);
        }
    }
}
