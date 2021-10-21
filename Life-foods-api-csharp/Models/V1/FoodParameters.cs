namespace Life_foods_api_csharp.Models.V1
{
    public class FoodParameters
    {
        const int maxPageSize = 20;
        private int _pageSize = 10;
        
        public int PageNumber { get; set; } = 1;
        
        
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}