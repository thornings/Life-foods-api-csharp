

namespace Life_foods_api_csharp.Models.V1.Auth
{
    public class JWTSettings
    {
        public string Secret { get; set; }
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }

    }
}
