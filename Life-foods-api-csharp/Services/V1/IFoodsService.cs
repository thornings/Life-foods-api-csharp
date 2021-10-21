using Life_foods_api_csharp.Models.V1;
using Life_foods_api_csharp.Models.V1.Other;

namespace Life_foods_api_csharp.Services.V1
{
    public interface IFoodsService
    {
        public ListWithPageInformations<Food> GetAllFoods(FoodParameters foodParameters);
    }
}
