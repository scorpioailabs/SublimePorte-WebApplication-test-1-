using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Common.Queries
{
    public class PagedQueryResult<T>
    {
        public PagedQueryResult(List<T> items, int? totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }

        public List<T> Items { get; set; }
        public int? TotalCount { get; set; }
    }
}
