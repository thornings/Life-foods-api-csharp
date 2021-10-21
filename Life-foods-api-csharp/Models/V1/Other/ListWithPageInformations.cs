using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_foods_api_csharp.Models.V1.Other
{
    public class ListWithPageInformations<T> : List<T>
    {
        public int Current { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => Current > 1;
        public bool HasNext => Current < TotalPages;

        public ListWithPageInformations(IQueryable<T> source, FoodParameters foodParameters)
        {
            var newItems = source.Skip((foodParameters.PageNumber - 1) * foodParameters.PageSize).Take(foodParameters.PageSize).ToList();
            TotalCount = newItems.Count;
            PageSize = foodParameters.PageSize;
            Current = foodParameters.PageNumber;
            TotalPages = (int)Math.Ceiling(newItems.Count / (double)foodParameters.PageSize);
            AddRange(newItems);
        }

        public object PagedInformation()
        {
            {
                return new
                {
                    this.TotalCount,
                    this.PageSize,
                    this.Current,
                    this.TotalPages,
                    this.HasNext,
                    this.HasPrevious
                };
            }
        }
    }
}
