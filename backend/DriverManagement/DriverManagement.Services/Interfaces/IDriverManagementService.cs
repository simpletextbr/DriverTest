using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriverManagement.Application.ViewModels;

namespace DriverManagement.Services.Interfaces
{
    public interface IDriverManagementService
    {
        Task<List<DriverViewModel>> GetAllDrivers();
        Task<DriverViewModel> GetDriverById(Guid id);
        Task<DriverViewModel> CreateDriver(DriverViewModel entity);
        Task<DriverViewModel> UpdateDriver(DriverViewModel entity);
        Task DeleteDriver(Guid id);
    }
}