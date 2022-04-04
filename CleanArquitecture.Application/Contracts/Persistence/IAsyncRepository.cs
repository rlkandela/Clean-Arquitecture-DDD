﻿using CleanArquitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArquitecture.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> pred);

        Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>>? pred = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeString = null,
            bool disableTracking = true);

        Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>>? pred = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            List<Expression<Func<T, object>>>? includes = null,
            bool disableTracking = true);

        Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> pred);

        Task<T?> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        void AddEntity(T entity);

        void UpdateEntity(T entity);

        void DeleteEntity(T entity);
    }
}
