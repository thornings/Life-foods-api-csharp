using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life_foods_api_csharp.Models.V1
{
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }

        [Required]
        [StringLength(200)]
        public string IngredientName { get; set; }

        public ICollection<Food> Foods { get; set; }

        public List<FoodIngredient> FoodIngredients { get; set; }
    }
}

