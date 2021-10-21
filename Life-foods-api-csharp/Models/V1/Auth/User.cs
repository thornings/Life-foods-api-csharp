using Microsoft.AspNetCore.Identity;

namespace Life_foods_api_csharp.Models.V1.Auth
{
    public class User : IdentityUser
    {
        public User()
        {
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
