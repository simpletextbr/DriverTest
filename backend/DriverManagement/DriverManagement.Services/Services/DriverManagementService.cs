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

        public async Task<DriverViewModel> Create(DriverViewModel entity)
        {
            var driver = new DriverModel(){
                Id = Guid.NewGuid(),
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

        public async Task Delete(Guid id)
        {
            var driver = await _driverRepository.GetById(id);

            if(driver == null)
                throw new Exception("Driver not found");

             await _driverRepository.Delete(id);
        }

        public async Task<List<DriverViewModel>> GetAll()
        {
            var driver = await _driverRepository.GetAll();
            var result = _mapper.Map<List<DriverViewModel>>(driver);
            return result;
        }

        public async Task<DriverViewModel> GetById(Guid id)
        {
            var driver = await _driverRepository.GetById(id);

            if(driver == null)
                throw new Exception("Driver not found");

            var result = _mapper.Map<DriverViewModel>(driver);
            return result;
        }

        public async Task<DriverViewModel> Update(DriverViewModel entity)
        {
            var driver = await _driverRepository.GetById(entity.Id);
             
            if(driver == null)
                throw new Exception("Driver not found");
            
            driver = _mapper.Map(entity, driver);
            var result = await _driverRepository.Update(driver);
            return _mapper.Map<DriverViewModel>(result);
        }
    }
}