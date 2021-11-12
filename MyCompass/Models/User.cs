using System.ComponentModel.DataAnnotations;

namespace MyCompass.Models
{
    public enum UserType
    {
        Client,
        Admin
    }

    public class User
    {
        [Key]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(3)]
        [MaxLength(18)]

        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        
        [Range(0, 120)]
        public int Age { get; set; }

        public UserType Type { get; set; } = UserType.Client;
    }
}
