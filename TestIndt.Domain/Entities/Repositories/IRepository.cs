﻿using System.Linq.Expressions;

namespace TestIndt.Domain.Entities.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        Task<TEntity> GetByIdAsync(long id);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
