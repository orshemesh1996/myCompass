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

        public DbSet<MyCompass.Models.TripEventModel> TripEventModel { get; set; }

        public DbSet<MyCompass.Models.UserModel> UserModel { get; set; }

        public DbSet<MyCompass.Models.TripCategoriesModel> TripCategoriesModel { get; set; }

        public DbSet<MyCompass.Models.PlacesModel> PlacesModel { get; set; }
    }
}
