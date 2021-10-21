using System.ComponentModel.DataAnnotations;

namespace Life_foods_api_csharp.Models.V1.Auth
{
    public class RegisterModel 
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
