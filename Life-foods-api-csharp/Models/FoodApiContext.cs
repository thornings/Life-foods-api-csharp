using Life_foods_api_csharp.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Life_foods_api_csharp.Models
{
    public class FoodApiContext : IdentityDbContext<User, Role, string>
    {
        public FoodApiContext(DbContextOptions<FoodApiContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Food>()
                .HasAlternateKey(f => f.Name);

            modelBuilder.Entity<Food>()
                .HasMany(x => x.Ingredients)
                .WithMany(x => x.Foods)
               .UsingEntity<FoodIngredient>(
                j => j
                    .HasOne(pt => pt.Ingredient)
                    .WithMany(t => t.FoodIngredients)
                    .HasForeignKey(pt => pt.IngredientId),
                j => j
                    .HasOne(pt => pt.Food)
                    .WithMany(p => p.FoodIngredients)
                    .HasForeignKey(pt => pt.FoodId),
                j =>
                {
                    j.HasKey(t => new { t.FoodId, t.IngredientId });
                });


            modelBuilder.Entity<Ingredient>()
               .HasAlternateKey(i => i.IngredientName);
            modelBuilder.Entity<Ingredient>().HasData(
                new { IngredientId = 1, IngredientName = "Polyols" },
                new { IngredientId = 2, IngredientName = "Salatrim" },
                new { IngredientId = 3, IngredientName = "Alcohol" },
                new { IngredientId = 4, IngredientName = "Organicasic" },
                new { IngredientId = 5, IngredientName = "Fibers" }
            );
        }

        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Ingredient> IngredientNames { get; set; }
        public virtual DbSet<FoodIngredient> FoodIngredients { get; set; }

        //[NotMapped]
        public virtual DbSet<User> Users { get; set; }
    }
}
