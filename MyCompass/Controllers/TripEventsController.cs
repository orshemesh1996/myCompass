using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCompass.Data;
using MyCompass.Models;
using MyCompass.Services;

namespace MyCompass.Controllers
{
    public class EventData
    {
        public int Count
        {
            get;
            set;
        }
        public string Place
        {
            get;
            set;
        }
    }

    [Authorize]
    public class TripEventsController : Controller
    {
        private readonly MyCompassContext _context;
        private readonly TripEventService _service;


        public TripEventsController(MyCompassContext context,TripEventService service )
        {
            _context = context;
            _service = service;
        }

      
        // GET: TripEvents
        public async Task<IActionResult> Index()
        {
            var webApplication16Context = _context.TripEventModel.Include(c => c.Place);
            return View(await webApplication16Context.ToListAsync());
        }

        public async Task<IActionResult> Search(string NameTrip,DateTime From, int Duration)
        {
            var trips = _service.Search(NameTrip, From, Duration);
            return View("Index", await trips.ToListAsync());
        }

        public List<EventData> CountNumberOfEventsByTrip()
        {
            List<EventData> placesObject = (from tripEvent in _context.TripEventModel
                                            join place in _context.PlacesModel on tripEvent.PlaceId equals place.Id
                                            group place by place.Name into g
                                            select new EventData
                                            {
                                                Place = g.Key,
                                                Count = g.Count()
                                            }).ToList();

            return placesObject;
        }

        // GET: TripEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripEvent = await _context.TripEventModel
                .Include(a => a.Categories).Include(b => b.Place).FirstOrDefaultAsync(m => m.Id == id);

            if (tripEvent == null)
            {
                return NotFound();
            }

            ViewData["CategoryNames"] = new SelectList(_context.Set<TripCategories>(), "Id", "Name");
            ViewData["PlaceName"] = new SelectList(_context.Set<Place>(), "Id", "Name");
            return View(tripEvent);
        }

        // GET: TripEvents/Create
        public IActionResult Create()
        {
            ViewData["CategoryNames"] = new SelectList(_context.Set<TripCategories>(), "Id", "Name");
            ViewData["PlaceName"] = new SelectList(_context.Set<Place>(), "Id", "Name");
            return View();
        }

        // POST: TripEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Categories,PlaceId,Date,Duration,Notes")] TripEvent tripEvent, int[] categories)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                var a = _context.TripCategoriesModel.Where(x => categories.Contains(x.Id));
                tripEvent.Categories = new List<TripCategories>();
                tripEvent.Categories.AddRange(a);

                _context.Add(tripEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tripEvent);
        }

        // GET: TripEvents/Edit/5
        [Authorize(Roles = "Admin")]
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

            ViewData["CategoryNames"] = new SelectList(_context.Set<TripCategories>(), "Id", "Name");
            ViewData["PlaceName"] = new SelectList(_context.Set<Place>(), "Id", "Name");
            return View(tripEvent);
        }

        // POST: TripEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Categories,PlaceId,Date,Duration,Notes")] TripEvent tripEvent, int[] categories)
        {
            if (id != tripEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var a = _context.TripCategoriesModel.Where(x => categories.Contains(x.Id));
                    var UpdateTripEvent = _context.TripEventModel.Include(t => t.Categories).FirstOrDefault(x => x.Id == id);

                    UpdateTripEvent.Categories = a.ToList();
                    UpdateTripEvent.Date = tripEvent.Date;
                    UpdateTripEvent.Duration = tripEvent.Duration;
                    UpdateTripEvent.Id = tripEvent.Id;
                    UpdateTripEvent.PlaceId = tripEvent.PlaceId;
                    UpdateTripEvent.Title = tripEvent.Title;
                    UpdateTripEvent.Place = tripEvent.Place;
                    UpdateTripEvent.Notes = tripEvent.Notes;


                    tripEvent.Categories = UpdateTripEvent.Categories;


                    _context.Update(UpdateTripEvent);
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
        [Authorize(Roles = "Admin")]
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
