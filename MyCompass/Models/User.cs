using System.ComponentModel.DataAnnotations;

namespace MyCompass.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "This field is mandatory")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string FacebookId { get; set; }

        public string AccessToken { get; set; }

        public bool IsAdmin { get; set; }
    }
}
