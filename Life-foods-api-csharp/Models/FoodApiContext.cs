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
            //   .HasName("AlternateKey_IngredientName");
        }
    }
}
