﻿using ApartmentService.DataAccess.InterfaceRepositories;
using ApartmentService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentService.DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataContext _dataContext { get; set; }
        internal DbSet<T> dbSet;

        public RepositoryBase(DataContext repoContext)
        {
            _dataContext = repoContext;
            this.dbSet = _dataContext.Set<T>();
        }
        public void Create(T entity)
        {
            _dataContext.Set<T>().AddAsync(entity);
            _dataContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
            _dataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dataContext.Set<T>().Update(entity);
            _dataContext.SaveChanges();
        }
        public IQueryable<T> FindAll()
        {
            return _dataContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dataContext.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AnyAsync(predicate);
        }

        public virtual async Task<bool> AddRange(IEnumerable<T> entity)
        {
            await dbSet.AddRangeAsync(entity);
            var result = await _dataContext.SaveChangesAsync();
            return result > 0;
        }

        public virtual async Task<bool> UpdateRange(IEnumerable<T> entity)
        {
            dbSet.UpdateRange(entity);
            var result = _dataContext.SaveChanges();
            return result > 0;
        }

        public virtual async Task<bool> RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
            var result = await _dataContext.SaveChangesAsync();
            return result > 0;
        }

        
    }
}
