using Microsoft.AspNetCore.Identity;
using System;

namespace Life_foods_api_csharp.Models.Auth
{
    public class Role : IdentityRole
    {
        public Role() { }

        public Role(string name)
        {
            Name = name;
        }

    }
}
