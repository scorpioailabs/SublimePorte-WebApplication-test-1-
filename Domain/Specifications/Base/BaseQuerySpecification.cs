using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Domain.Specifications.Base
{
    public abstract class BaseQuerySpecification
    {
        public SortOrder SortOrder { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public bool PerformCount { get; set; }
        public bool DisableTracking { get; set; }

        public List<string> StringIncludes { get; set; } = new List<string>();

        public bool PerformPagination
        {
            get
            {
                return ((Take.HasValue && Take.Value > 0) && (Skip.HasValue && Skip.Value > 0));
            }
        }
    }
}
