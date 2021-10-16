using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompass.Models
{
    public class TripEventModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("TripCategories")]
        public string Category { get; set; }
        public string Date { get; set; }
        public int Duration { get; set; }
        public string Place { get; set; }
        public string Notes { get; set; }
    }
}
