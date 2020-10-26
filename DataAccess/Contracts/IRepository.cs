using DataAccess.Query;
using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> FindAll(Pagination pagination, Expression<Func<T, bool>> filter, string include = null);
        T Find(int id);
        void Insert(T entity);
        void Insert(List<T> entities);
        void Update(T entity);
        void Update(List<T> entities);
        void Delete(int id);
        int Count();
        void DeleteAll();
    }
}
