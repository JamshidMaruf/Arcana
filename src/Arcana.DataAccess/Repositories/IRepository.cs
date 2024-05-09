using Arcana.Domain.Commons;
using System.Linq.Expressions;

namespace Arcana.DataAccess.Repositories;

public interface IRepository<T> where T : Auditable
{
    ValueTask<T> InsertAsync(T entity);
    ValueTask BulkInsertAsync(IEnumerable<T> entities);
    ValueTask<T> UpdateAsync(T entity);
    ValueTask BulkUpdateAsync(IEnumerable<T> entities);
    ValueTask<T> DeleteAsync(T entity);
    ValueTask BulkDeleteAsyn(IEnumerable<T> entities);
    ValueTask<T> DropAsync(T entity);
    ValueTask BulkDropAsync(IEnumerable<T> entities);
    ValueTask<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null);
    ValueTask<IEnumerable<T>> SelectAsEnumerableAsync(
        Expression<Func<T, bool>> expression = null,
        string[] includes = null,
        bool isTracked = true);
    IQueryable<T> SelectAsQueryable(
        Expression<Func<T, bool>> expression = null,
        string[] includes = null,
        bool isTracked = true);
}