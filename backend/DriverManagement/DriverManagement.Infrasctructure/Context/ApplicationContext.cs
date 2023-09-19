using System.Reflection;
using DriverManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DriverManagement.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<DriverModel> Drivers => Set<DriverModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
