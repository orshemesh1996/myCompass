using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompass.Models
{
    public class TripEvent
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public List<TripCategories> Categories { get; set; }

        [Required]
        [Display(Name = "Place Name")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public string Notes { get; set; }
    }
}
