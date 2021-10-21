using Life_foods_api_csharp.Models.V1;
using Life_foods_api_csharp.Models.V1.Other;
using Life_foods_api_csharp.Services.V1;

namespace Life_foods_api_csharp.Services
{
    public class FoodsService : IFoodsService
    {
        private FoodApiContext _context;

        public FoodsService(FoodApiContext context)
        {            
            _context = context;
        }

        public ListWithPageInformations<Food> GetAllFoods(FoodParameters foodParameters)
        {
            var foodsQuery = _context.Foods.AsQueryable();
            return new ListWithPageInformations<Food>(foodsQuery, foodParameters);
        }

       
    }
}
