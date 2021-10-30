using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCompass.Models;

namespace MyCompass.Data
{
    public class MyCompassContext : DbContext
    {
        public MyCompassContext (DbContextOptions<MyCompassContext> options)
            : base(options)
        {
        }

        public DbSet<MyCompass.Models.TripEvent> TripEventModel { get; set; }

        public DbSet<MyCompass.Models.User> UserModel { get; set; }

        public DbSet<MyCompass.Models.TripCategories> TripCategoriesModel { get; set; }

        public DbSet<MyCompass.Models.Place> PlacesModel { get; set; }

        public DbSet<MyCompass.Models.PlaceImage> PlaceImage { get; set; }
    }
}
