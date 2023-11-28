using System;
using System.Threading.Tasks;

namespace ToDoProject.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<T> Repository<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
