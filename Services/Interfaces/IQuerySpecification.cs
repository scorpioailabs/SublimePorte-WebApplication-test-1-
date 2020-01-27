using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SublimePorteApplication.Services.Interfaces
{
    public interface IQuerySpecification<T>
    {
        Expression<Func<T, bool>> WhereClause { get; set; }
        List<Expression<Func<T, object>>> Includes { get; set; }
        List<string> StringIncludes { get; set; }
        Expression<Func<T, dynamic>> OrderBy { get; set; }
        SortOrder SortOrder { get; set; }
        int? Skip { get; set; }
        int? Take { get; set; }
        bool PerformCount { get; set; }
        bool PerformPagination { get; }
        bool DisableTracking { get; }
    }

    public enum SortOrder
    {
        Ascending = 1,
        Descending = 2
    }
}
