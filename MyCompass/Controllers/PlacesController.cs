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
    public class PlacesController : Controller
    {
        private readonly MyCompassContext _context;

        public PlacesController(MyCompassContext context)
        {
            _context = context;
        }

        // GET: Places
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlacesModel.ToListAsync());
        }

        // GET: Places/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placesModel = await _context.PlacesModel
                .FirstOrDefaultAsync(m => m.Name == id);
            if (placesModel == null)
            {
                return NotFound();
            }

            return View(placesModel);
        }

        // GET: Places/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Latitude,Longitude")] PlacesModel placesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(placesModel);
        }

        // GET: Places/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placesModel = await _context.PlacesModel.FindAsync(id);
            if (placesModel == null)
            {
                return NotFound();
            }
            return View(placesModel);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,Latitude,Longitude")] PlacesModel placesModel)
        {
            if (id != placesModel.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacesModelExists(placesModel.Name))
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
            return View(placesModel);
        }

        // GET: Places/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placesModel = await _context.PlacesModel
                .FirstOrDefaultAsync(m => m.Name == id);
            if (placesModel == null)
            {
                return NotFound();
            }

            return View(placesModel);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var placesModel = await _context.PlacesModel.FindAsync(id);
            _context.PlacesModel.Remove(placesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacesModelExists(string id)
        {
            return _context.PlacesModel.Any(e => e.Name == id);
        }
    }
}
