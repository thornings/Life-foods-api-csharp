using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_foods_api_csharp.Models
{
    public class FoodApiContext : DbContext
    {
        public FoodApiContext(DbContextOptions<FoodApiContext> options)
    :       base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>()
                .HasAlternateKey(f => f.Name);
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

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal  { get; set; } = 0;

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal  { get; set; } = 0;

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal  { get; set; } = 0;

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal  { get; set; } = 0;

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal  { get; set; } = 0;

    }
}
