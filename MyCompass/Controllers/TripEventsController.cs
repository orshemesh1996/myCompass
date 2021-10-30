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
    public class TripEventsController : Controller
    {
        private readonly MyCompassContext _context;

        public TripEventsController(MyCompassContext context)
        {
            _context = context;
        }

        // GET: TripEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.TripEventModel.ToListAsync());
        }

        // GET: TripEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripEvent = await _context.TripEventModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripEvent == null)
            {
                return NotFound();
            }

            return View(tripEvent);
        }

        // GET: TripEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TripEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Date,Duration,Notes")] TripEvent tripEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tripEvent);
        }

        // GET: TripEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripEvent = await _context.TripEventModel.FindAsync(id);
            if (tripEvent == null)
            {
                return NotFound();
            }
            return View(tripEvent);
        }

        // POST: TripEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date,Duration,Notes")] TripEvent tripEvent)
        {
            if (id != tripEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripEventExists(tripEvent.Id))
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
            return View(tripEvent);
        }

        // GET: TripEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripEvent = await _context.TripEventModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripEvent == null)
            {
                return NotFound();
            }

            return View(tripEvent);
        }

        // POST: TripEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tripEvent = await _context.TripEventModel.FindAsync(id);
            _context.TripEventModel.Remove(tripEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripEventExists(int id)
        {
            return _context.TripEventModel.Any(e => e.Id == id);
        }
    }
}
