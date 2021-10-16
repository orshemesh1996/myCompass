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
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCategoriesModel = await _context.TripCategoriesModel
                .FirstOrDefaultAsync(m => m.Name == id);
            if (tripCategoriesModel == null)
            {
                return NotFound();
            }

            return View(tripCategoriesModel);
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
        public async Task<IActionResult> Create([Bind("Name")] TripCategoriesModel tripCategoriesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripCategoriesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tripCategoriesModel);
        }

        // GET: TripCategories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCategoriesModel = await _context.TripCategoriesModel.FindAsync(id);
            if (tripCategoriesModel == null)
            {
                return NotFound();
            }
            return View(tripCategoriesModel);
        }

        // POST: TripCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name")] TripCategoriesModel tripCategoriesModel)
        {
            if (id != tripCategoriesModel.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripCategoriesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripCategoriesModelExists(tripCategoriesModel.Name))
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
            return View(tripCategoriesModel);
        }

        // GET: TripCategories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCategoriesModel = await _context.TripCategoriesModel
                .FirstOrDefaultAsync(m => m.Name == id);
            if (tripCategoriesModel == null)
            {
                return NotFound();
            }

            return View(tripCategoriesModel);
        }

        // POST: TripCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tripCategoriesModel = await _context.TripCategoriesModel.FindAsync(id);
            _context.TripCategoriesModel.Remove(tripCategoriesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripCategoriesModelExists(string id)
        {
            return _context.TripCategoriesModel.Any(e => e.Name == id);
        }
    }
}
