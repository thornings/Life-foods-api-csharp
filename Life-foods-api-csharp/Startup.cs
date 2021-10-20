using Life_foods_api_csharp.Models;
using Life_foods_api_csharp.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life_foods_api_csharp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddCors();

            //var appSecretSettingsSection = Configuration.GetSection("AppSettings");
            //services.Configure<SecretSettings>(appSecretSettingsSection);

            services.AddDbContext<FoodApiContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("FoodConnection")));

            services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<FoodApiContext>()
               .AddDefaultTokenProviders();

            //options.Password.RequireDigit = true;
            //options.Password.RequireLowercase = true;
            //options.Password.RequireNonAlphanumeric = true;
            //options.Password.RequireUppercase = true;
            //options.Password.RequiredLength = 6;
            //options.Password.RequiredUniqueChars = 1;


            //var appSettings = appSecretSettingsSection.Get<SecretSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});

            // configure DI for application services
            //  services.AddScoped<IUserService, UserService>();


            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Life_foods_api_csharp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Life_foods_api_csharp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // set the global cors policy for vue
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
