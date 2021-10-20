using Microsoft.AspNetCore.Identity;
using System;

namespace Life_foods_api_csharp.Models.Auth
{
    public class User : IdentityUser
    {
        public User()
        {
        }

        //public override Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
