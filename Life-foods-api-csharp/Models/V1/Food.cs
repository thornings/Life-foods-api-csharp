using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Life_foods_api_csharp.Models.V1
{
    public class Food
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Weight { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Carbs { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Fats { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Proteins { get; set; } = 0;
       
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Energy { get; set; } = 0;

        public ICollection<Ingredient> Ingredients { get; set; }

        public List<FoodIngredient> FoodIngredients { get; set; }
    }
}

