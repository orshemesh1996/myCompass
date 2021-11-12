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
        public IQueryable<TripEvent> Search(string tripName, DateTime From, int Duration)
        {
            bool ignoreDuration = false;
            
            if (Duration == 0)
            {
                ignoreDuration = true;
            }

            bool ignoreFrom = false;
            DateTime dummy = new DateTime { };
            if (From == dummy)
            {
                ignoreFrom = true;
            }

            bool ignoreTripName = false;
            if (tripName == null)
            {
                ignoreTripName = true;
            }

            var webApplication16Context = from tripEvent in _context.TripEventModel
                                          where (ignoreTripName || tripEvent.Title.Contains(tripName)) &&
                                          (ignoreFrom || tripEvent.Date > From) &&
                                          (ignoreDuration || tripEvent.Duration == Duration)
                                          select tripEvent;
            return webApplication16Context;
        }
    }
}
