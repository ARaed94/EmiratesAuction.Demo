using Entities.Modules.Core;

namespace DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        void Rollback();
    }
}
