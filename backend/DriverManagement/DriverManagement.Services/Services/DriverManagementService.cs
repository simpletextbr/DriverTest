
using DriverManagement.Application.ViewModels;
using DriverManagement.Domain.interfaces;
using DriverManagement.Services.Interfaces;

namespace DriverManagement.Services.Services
{
    public class DriverManagementService : IDriverManagementService
    {
        protected readonly IDriverRepository _driverRepository;

        public Task<DriverViewModel> Create(DriverViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DriverViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DriverViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DriverViewModel> Update(DriverViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}