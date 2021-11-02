using MyCompass.Data;
using MyCompass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompass.Services
{
    public class TripEventService
    {
        private readonly MyCompassContext _context;

        public TripEventService(MyCompassContext context)
        {
            _context = context;
        }
        public IQueryable<TripEvent> Search(string NameTrip, DateTime From)
        {
            // var articles = _context.TripEventModel.Where(x => x.Title.Contains(NameTrip));
            var webApplication16Context = from tripEvent in _context.TripEventModel
                                          where tripEvent.Title.Contains(NameTrip) || tripEvent.Date > From
                                          select tripEvent;
            return webApplication16Context;
        }
    }
}
