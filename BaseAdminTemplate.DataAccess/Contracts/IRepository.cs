using System;
using System.Linq;
using System.Linq.Expressions;

using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> GetActiveEntities();
        IQueryable<T> GetInActiveEntities();
        IQueryable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        void SoftDelete(Guid id);
        void HardDelete(Guid id);
        void Restore(Guid id);
    }
}