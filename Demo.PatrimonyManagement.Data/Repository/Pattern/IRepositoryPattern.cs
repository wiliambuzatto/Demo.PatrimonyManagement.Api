using Demo.PatrimonyManagement.Domain.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.PatrimonyManagement.Data.Repository.Pattern
{
    public interface IRepositoryPattern<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(IncludeList<TEntity> includes, params object[] keyValues);
        Task<TEntity> FindAsync(IncludeList<TEntity> includes, Expression<Func<TEntity, bool>> filter);
        Task<PagedList<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> order, int page, int itemsPerPage);
        Task<PagedList<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> order, int page, int itemsPerPage, IncludeList<TEntity> includes);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(params object[] keyValues);
        Task DeleteAsync(TEntity entity);

        IQueryable<TEntity> Get();

        TEntity Find(params object[] keyValues);
        TEntity Find(IncludeList<TEntity> includes, params object[] keyValues);
        TEntity Find(Expression<Func<TEntity, bool>> filter);
        TEntity Find(IncludeList<TEntity> includes, Expression<Func<TEntity, bool>> filter);

        PagedList<TEntity> Get<TKey>(Expression<Func<TEntity, TKey>> order);
        PagedList<TEntity> Get<TKey>(Expression<Func<TEntity, TKey>> order, IncludeList<TEntity> includes);
        PagedList<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> order);
        PagedList<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> order, IncludeList<TEntity> includes);
        PagedList<TEntity> Get<TKey>(Expression<Func<TEntity, TKey>> order, int page, int itemsPerPage);
        PagedList<TEntity> Get<TKey>(Expression<Func<TEntity, TKey>> order, int page, int itemsPerPage, IncludeList<TEntity> includes);
        PagedList<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> order, int page, int itemsPerPage);
        PagedList<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> order, int page, int itemsPerPage, IncludeList<TEntity> includes);

        int Count(Expression<Func<TEntity, bool>> filter);
        bool Any(Expression<Func<TEntity, bool>> filter);

        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(params object[] keyValues);
        void Delete(TEntity entity);
    }
}
