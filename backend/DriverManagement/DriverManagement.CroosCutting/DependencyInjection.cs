
using DriverManagement.Domain.interfaces;
using DriverManagement.Infrasctructure.Repositories;
using DriverManagement.Infrastructure.Context;
using DriverManagement.Services.Interfaces;
using DriverManagement.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DriverManagement.CroosCutting
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration){
            
            #region Repositories
            services.AddScoped<IDriverRepository, DriverRepository>();
            #endregion

            #region Services
            services.AddScoped<IDriverManagementService, DriverManagementService>();
            #endregion


            #region DbContext
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            #endregion
        }
    }
}