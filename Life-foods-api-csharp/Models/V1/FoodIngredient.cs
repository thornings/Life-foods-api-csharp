﻿
namespace Life_foods_api_csharp.Models.V1
{
    public class FoodIngredient
    {
            public int FoodId { get; set; }

            public Food Food { get; set; }
            
            public int IngredientId { get; set; }

            public Ingredient Ingredient { get; set; }
    }
}
