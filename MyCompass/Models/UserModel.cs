using System.ComponentModel.DataAnnotations;

namespace MyCompass.Models
{
    public class UserModel
    {
        [Key]
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string PhotoURL { get; set; }
        public string FacebookId { get; set; }
        public string AccessToken { get; set; }
        public bool IsAdmin { get; set; }
    }
}
