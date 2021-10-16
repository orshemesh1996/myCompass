using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCompass.Data;
using MyCompass.Models;

namespace MyCompass.Controllers
{
    public class TripEventController : Controller
    {
        private readonly MyCompassContext _context;

        public TripEventController(MyCompassContext context)
        {
            _context = context;
        }

        // GET: TripEvent
        public async Task<IActionResult> Index()
        {
            return View(await _context.TripEventModel.ToListAsync());
        }

        // GET: TripEvent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripEventModel = await _context.TripEventModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripEventModel == null)
            {
                return NotFound();
            }

            return View(tripEventModel);
        }

        // GET: TripEvent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TripEvent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Category,Date,Duration,Place,Notes")] TripEventModel tripEventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripEventModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tripEventModel);
        }

        // GET: TripEvent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripEventModel = await _context.TripEventModel.FindAsync(id);
            if (tripEventModel == null)
            {
                return NotFound();
            }
            return View(tripEventModel);
        }

        // POST: TripEvent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Category,Date,Duration,Place,Notes")] TripEventModel tripEventModel)
        {
            if (id != tripEventModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripEventModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripEventModelExists(tripEventModel.Id))
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
            return View(tripEventModel);
        }

        // GET: TripEvent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripEventModel = await _context.TripEventModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripEventModel == null)
            {
                return NotFound();
            }

            return View(tripEventModel);
        }

        // POST: TripEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tripEventModel = await _context.TripEventModel.FindAsync(id);
            _context.TripEventModel.Remove(tripEventModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripEventModelExists(int id)
        {
            return _context.TripEventModel.Any(e => e.Id == id);
        }
    }
}
