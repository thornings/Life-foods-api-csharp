using Microsoft.AspNetCore.Identity;

namespace Life_foods_api_csharp.Models.V1.Auth
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
