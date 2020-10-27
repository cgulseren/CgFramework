using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter, bool noTracking = true);
        IList<T> GetAll(Expression<Func<T, bool>> filter = null, bool noTracking = true);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
