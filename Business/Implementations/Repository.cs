using DataAccess.Context;
using DataAccess.Contracts;
using DataAccess.Query;
using Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly ApplicationDbContext _dbContext;
        public readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _dbContext = context;
            _dbSet = this._dbContext.Set<T>();
        }
        public int Count()
        {
            return this._dbSet.Count();
        }
        public void Delete(int id)
        {
            // Find entity.
            T entity = this._dbSet.Find(id);

            if (entity == null)
            {
                throw new Exception("Entity was not found.");
            }

            entity.DeletedOn = DateTime.Now;

            this._dbSet.Attach(entity);
            this._dbContext.Entry(entity).State = EntityState.Modified;
        }
        public T Find(int id)
        {
            return this._dbSet.Find(id);
        }
        public List<T> FindAll(Pagination pagination, Expression<Func<T, bool>> filter, string include = null)
        {
            IQueryable<T> query = this._dbSet.Where(filter);

            query = CalculatePagination(query, pagination);

            if (string.IsNullOrEmpty(include) == false)
            {
                query = query.Include(include);
            }

            return query.ToList();
        }
        public void Insert(T entity)
        {
            entity.CreatedOn = DateTime.Now;
            this._dbSet.Add(entity);
        }
        public void Insert(List<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreatedOn = DateTime.Now;
            }
            this._dbSet.AddRange(entities);
        }
        public void Update(T entity)
        {
            entity.LastModifiedOn = DateTime.Now;
            throw new NotImplementedException();
        }
        public void Update(List<T> entities)
        {

        }
        public void DeleteAll()
        {
            _dbContext.Database.ExecuteSqlRaw($"DELETE FROM AuctionDetails");
            _dbContext.Database.ExecuteSqlRaw($"DELETE FROM Auctions");
        }
        public IQueryable<T> CalculatePagination(IQueryable<T> query, Pagination pagination)
        {
            if (pagination != null && pagination.PageNumber > 0 && pagination.PageSize > 0)
            {
                pagination.TotalRecords = query.Count();

                double totalRecords = Convert.ToDouble(pagination.TotalRecords);
                double pageSize = Convert.ToDouble(pagination.PageSize);
                pagination.TotalPages = Convert.ToInt32(Math.Ceiling(totalRecords / pageSize));

                query = query.OrderBy(o => o.Id);
                int skip = (pagination.PageNumber - 1) * pagination.PageSize;
                query = query.Skip(skip).Take(pagination.PageSize);
            }
            return query;
        }
    }
}
