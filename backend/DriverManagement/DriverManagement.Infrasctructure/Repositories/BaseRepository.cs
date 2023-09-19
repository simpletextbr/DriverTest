using DriverManagement.Domain;
using DriverManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DriverManagement.Infrasctructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel, new()
    {
        protected readonly DbContext Db;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(DbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<T> Create(T model)
        {
            DbSet.Add(model);
            await SaveChanges();
            return model;
        }

        public virtual async Task<T> Update(T model)
        {
            Db.ChangeTracker.Clear();
            DbSet.Update(model);
            await SaveChanges();
            return model;
        }

        public virtual async Task Delete(Guid id)
        {
            Db.ChangeTracker.Clear();
            DbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Db?.Dispose();
        }

    }
}