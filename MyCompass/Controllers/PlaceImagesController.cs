using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCompass.Data;
using MyCompass.Models;

namespace MyCompass.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PlaceImagesController : Controller
    {
        private readonly MyCompassContext _context;

        public PlaceImagesController(MyCompassContext context)
        {
            _context = context;
        }

        // GET: PlaceImages
        public async Task<IActionResult> Index()
        {
            var myCompassContext = _context.PlaceImage.Include(p => p.Place);
            return View(await myCompassContext.ToListAsync());
        }

        // GET: PlaceImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeImage = await _context.PlaceImage
                .Include(p => p.Place)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placeImage == null)
            {
                return NotFound();
            }

            return View(placeImage);
        }

        // GET: PlaceImages/Create
        public IActionResult Create()
        {
            ViewData["PlaceId"] = new SelectList(_context.PlacesModel.Where(p => p.PlaceImage == null), "Id", nameof(PlaceImage.Place.Name));
            return View();
        }

        // POST: PlaceImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageFile,PlaceId")] PlaceImage placeImage)
        {
            if (ModelState.IsValid)
            {
                if (placeImage.ImageFile != null)
                {
                    MemoryStream ms = new MemoryStream();
                    placeImage.ImageFile.CopyTo(ms);
                    placeImage.Image = ms.ToArray();
                }

                _context.Add(placeImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PlaceId"] = new SelectList(_context.PlacesModel, "Id", "Name", placeImage.PlaceId);
            return View(placeImage);
        }

        // GET: PlaceImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeImage = await _context.PlaceImage.FindAsync(id);
            if (placeImage == null)
            {
                return NotFound();
            }
            ViewData["PlaceId"] = new SelectList(_context.PlacesModel, "Id", "Name", placeImage.PlaceId);
            return View(placeImage);
        }

        // POST: PlaceImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageFile,PlaceId")] PlaceImage placeImage)
        {
            if (id != placeImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (placeImage.ImageFile != null)
                {
                    MemoryStream ms = new MemoryStream();
                    placeImage.ImageFile.CopyTo(ms);
                    placeImage.Image = ms.ToArray();
                }

                try
                {
                    _context.Update(placeImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceImageExists(placeImage.Id))
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
            ViewData["PlaceId"] = new SelectList(_context.PlacesModel, "Id", "Name", placeImage.PlaceId);
            return View(placeImage);
        }

        // GET: PlaceImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeImage = await _context.PlaceImage
                .Include(p => p.Place)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placeImage == null)
            {
                return NotFound();
            }

            return View(placeImage);
        }

        // POST: PlaceImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placeImage = await _context.PlaceImage.FindAsync(id);
            _context.PlaceImage.Remove(placeImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaceImageExists(int id)
        {
            return _context.PlaceImage.Any(e => e.Id == id);
        }
    }
}
