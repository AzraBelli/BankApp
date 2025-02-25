using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BankingCreditSystem.Core.Repositories;

public interface IAsyncRepository<TEntity,TId> where TEntity : Entity<TId>
{
    //GetAsync
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);
       
    //GetListAsync
    Task<Paginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,       
        CancellationToken cancellationToken = default);

    //AnyAsync
    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    //AddAsync
   
    Task<TEntity> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default);

    //AddRangeAsync
    Task<ICollection<TEntity>> AddRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default);

    //UpdateAsync
    Task<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default);

    //UpdateRangeAsync
    Task<ICollection<TEntity>> UpdateRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default);

    //DeleteAsync
    Task<TEntity> DeleteAsync(
        TEntity entity,
        bool permanent =false,
        CancellationToken cancellationToken = default);

    //DeleteRangeAsync
    Task<ICollection<TEntity>> DeleteRangeAsync(
        ICollection<TEntity> entities,
        bool permanent =false,
        CancellationToken cancellationToken = default);
} 