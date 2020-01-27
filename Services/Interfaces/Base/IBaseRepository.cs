using SublimePorteApplication.Common.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Services.Interfaces.Base
{
    public interface IBaseRepository<T>
    {
        Task<T> GetAsync(int Id);
        Task<PagedQueryResult<T>> PagedQueryAsync(IQuerySpecification<T> specification);
        Task<List<T>> QueryAsync(IQuerySpecification<T> specification);
        Task SaveChangesAsync();
        void Add(T item);
    }
}
