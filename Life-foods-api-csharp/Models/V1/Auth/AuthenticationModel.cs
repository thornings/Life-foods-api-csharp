using System.ComponentModel.DataAnnotations;

namespace Life_foods_api_csharp.Models.V1.Auth
{
    public class AuthenticationModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
