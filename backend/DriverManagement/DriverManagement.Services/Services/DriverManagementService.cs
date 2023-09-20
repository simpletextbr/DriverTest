using AutoMapper;
using DriverManagement.Application.ViewModels;
using DriverManagement.Domain.interfaces;
using DriverManagement.Domain.Models;
using DriverManagement.Services.Interfaces;

namespace DriverManagement.Services.Services
{
    public class DriverManagementService : IDriverManagementService
    {
        protected readonly IDriverRepository _driverRepository;
        protected readonly IMapper _mapper;

        public DriverManagementService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<DriverViewModel> CreateDriver(DriverViewModel entity)
        {
            var id  = entity.Id == Guid.Empty ? Guid.NewGuid() : entity.Id;

            var driver = new DriverModel(){
                Id = id,
                Name = entity.Name,
                DateOfBirth = entity.DateOfBirth,
                DrivingLicenseNumber = entity.DrivingLicenseNumber,
                DrivingLicenseExpirationDate = entity.DrivingLicenseExpirationDate,
                Email = entity.Email,
                City = entity.City
            };

            
            var result = await _driverRepository.Create(driver);
            return _mapper.Map<DriverViewModel>(result);
        }

        public async Task DeleteDriver(Guid id)
        {
            var driver = await _driverRepository.GetById(id);

            if(driver == null)
                throw new Exception("You can't delete a driver that doesn't exist");

             await _driverRepository.Delete(id);
        }

        public async Task<List<DriverViewModel>> GetAllDrivers()
        {
            var driver = await _driverRepository.GetAll();
            var result = _mapper.Map<List<DriverViewModel>>(driver);
            return result;
        }

        public async Task<DriverViewModel> GetDriverById(Guid id)
        {
            var driver = await _driverRepository.GetById(id);

            if(driver == null)
                throw new Exception("Driver not found");

            var result = _mapper.Map<DriverViewModel>(driver);
            return result;
        }

        public async Task<DriverViewModel> UpdateDriver(DriverViewModel entity)
        {
            var driver = await _driverRepository.GetById(entity.Id);
             
            if(driver == null)
                throw new Exception("You can't update a driver that doesn't exist");
            
            driver = _mapper.Map(entity, driver);
            var result = await _driverRepository.Update(driver);
            return _mapper.Map<DriverViewModel>(result);
        }
    }
}