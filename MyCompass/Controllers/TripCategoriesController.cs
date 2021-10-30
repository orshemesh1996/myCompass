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
    public class TripCategoriesController : Controller
    {
        private readonly MyCompassContext _context;

        public TripCategoriesController(MyCompassContext context)
        {
            _context = context;
        }

        // GET: TripCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.TripCategoriesModel.ToListAsync());
        }

        // GET: TripCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCategories = await _context.TripCategoriesModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripCategories == null)
            {
                return NotFound();
            }

            return View(tripCategories);
        }

        // GET: TripCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TripCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TripCategories tripCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tripCategories);
        }

        // GET: TripCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCategories = await _context.TripCategoriesModel.FindAsync(id);
            if (tripCategories == null)
            {
                return NotFound();
            }
            return View(tripCategories);
        }

        // POST: TripCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TripCategories tripCategories)
        {
            if (id != tripCategories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripCategoriesExists(tripCategories.Id))
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
            return View(tripCategories);
        }

        // GET: TripCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCategories = await _context.TripCategoriesModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripCategories == null)
            {
                return NotFound();
            }

            return View(tripCategories);
        }

        // POST: TripCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tripCategories = await _context.TripCategoriesModel.FindAsync(id);
            _context.TripCategoriesModel.Remove(tripCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripCategoriesExists(int id)
        {
            return _context.TripCategoriesModel.Any(e => e.Id == id);
        }
    }
}
