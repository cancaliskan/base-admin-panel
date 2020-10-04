using System;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.Domain.Entities;
using BaseAdminTemplate.DataAccess.Contracts;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbContext Context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            _dbSet = Context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return GetByCondition(entity => entity.Id == id && entity.IsActive).First();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }

        public IQueryable<T> GetActiveEntities()
        {
            return GetByCondition(entity => entity.IsActive);
        }

        public IQueryable<T> GetInActiveEntities()
        {
            return GetByCondition(entity => entity.IsActive == false);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public T Create(T entity)
        {
            entity.Id = Guid.NewGuid();
            entity.IsActive = true;
            entity.CreatedDate = DateTime.Now;
            _dbSet.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            _dbSet.Update(entity);
            return entity;
        }

        public void SoftDelete(Guid id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return;
            }

            entity.DeletedDate = DateTime.Now;
            entity.IsActive = false;
            Update(entity);
        }

        public void HardDelete(Guid id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return;
            }

            _dbSet.Remove(entity);
        }

        public void Restore(Guid id)
        {
            var entity = GetById(id);
            entity.IsActive = true;
            Update(entity);
        }
    }
}