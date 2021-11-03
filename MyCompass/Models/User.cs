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
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int Age { get; set; }

        public UserType Type { get; set; } = UserType.Client;
    }
}
