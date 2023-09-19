namespace DriverManagement.Domain
{
    public interface IBaseRepository<T> : BaseModel
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
    }
}