using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompass.Models
{
    public class PlaceImage
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        [NotMapped]
        [Display(Name = "Image File")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Place Name")]
        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
