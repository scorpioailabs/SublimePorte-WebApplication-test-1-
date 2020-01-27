using SublimePorteApplication.Domain.Specifications.Base;
using SublimePorteApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SublimePorteApplication.Domain.Specifications
{
    public class AccountQuerySpecification : BaseQuerySpecification, IQuerySpecification<User>
    {
        public Expression<Func<User, bool>> WhereClause { get; set; }
        public List<Expression<Func<User, object>>> Includes { get; set; } = new List<Expression<Func<User, object>>>();
        public Expression<Func<User, dynamic>> OrderBy { get; set; }
        SortOrder IQuerySpecification<User>.SortOrder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
