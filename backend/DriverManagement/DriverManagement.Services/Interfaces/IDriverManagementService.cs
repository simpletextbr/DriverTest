using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriverManagement.Application.ViewModels;

namespace DriverManagement.Services.Interfaces
{
    public interface IDriverManagementService
    {
        Task<List<DriverViewModel>> GetAll();
        Task<DriverViewModel> GetById(Guid id);
        Task<DriverViewModel> Create(DriverViewModel entity);
        Task<DriverViewModel> Update(DriverViewModel entity);
        Task Delete(Guid id);
    }
}