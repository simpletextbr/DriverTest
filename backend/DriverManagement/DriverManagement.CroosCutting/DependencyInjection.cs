using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriverManagement.Domain.interfaces;
using DriverManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DriverManagement.CroosCutting
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration){
            



            #region DbContext
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            #endregion
        }
    }
}