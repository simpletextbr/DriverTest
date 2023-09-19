using DriverManagement.Domain.Models;

namespace DriverManagement.Domain
{
    public interface IBaseRepository<T> : IDisposable
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(Guid id);
    }
}