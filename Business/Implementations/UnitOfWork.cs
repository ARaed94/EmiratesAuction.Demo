using DataAccess.Context;
using DataAccess.Contracts;
using Entities.Modules.Core;

namespace Business.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public void Rollback()
        {
            _dbContext.Dispose();
        }
    }
}
