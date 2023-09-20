using AutoMapper;
using DriverManagement.Application.AutoMapper;
using DriverManagement.Infrasctructure.Repositories;
using DriverManagement.Infrastructure.Context;
using DriverManagement.Services.Interfaces;
using DriverManagement.Services.Services;
using DriverManagement.Tests.Faker;
using Microsoft.EntityFrameworkCore;

namespace DriverManagement.Tests.Services.DriverManagement
{
    public class DeleteDriver
    {
        [Fact]
        public async Task DeleteDriver_Success(){
            // Arrange
            var service = Service();
            var viewModelFake = DriverViewModelFacker.GenerateDriverViewModel().Generate();
            var viewModelToBeDeleted = DriverViewModelFacker.GenerateDriverViewModel().Generate();

            await service.CreateDriver(viewModelFake);
            await service.CreateDriver(viewModelToBeDeleted);

            var GetAllDrivers = await service.GetAllDrivers();

            Assert.Equal(2, GetAllDrivers.Count);
            // Act
            
            await service.DeleteDriver(viewModelToBeDeleted.Id);
            var GetAllDriversAfterDelete = await service.GetAllDrivers();

            // Assert
            Assert.Equal(1, GetAllDriversAfterDelete.Count);
            Assert.Equal(viewModelFake.Name, GetAllDriversAfterDelete[0].Name);
            Assert.Equal(viewModelFake.DateOfBirth, GetAllDriversAfterDelete[0].DateOfBirth);
            Assert.Equal(viewModelFake.DrivingLicenseNumber, GetAllDriversAfterDelete[0].DrivingLicenseNumber);
            Assert.Equal(viewModelFake.DrivingLicenseExpirationDate, GetAllDriversAfterDelete[0].DrivingLicenseExpirationDate);
            Assert.Equal(viewModelFake.Email, GetAllDriversAfterDelete[0].Email);
            Assert.Equal(viewModelFake.City, GetAllDriversAfterDelete[0].City);        
        }

        [Fact]
        public async Task DeleteDriver_Failed(){
            // Arrange
            var service = Service();
            // Act
            var fakeId = Guid.NewGuid();
            // Assert
            await Assert.ThrowsAsync<Exception>(() => service.DeleteDriver(fakeId));
     
        }

        private static IDriverManagementService Service()
        {
            DbContextOptions<ApplicationContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("DriverManagmentService.Delete");
            options = builder.Options;
            var context = new ApplicationContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var _driverRepository = new DriverRepository(context);

            var mapper = new Mapper(AutoMapperSetup.RegisterMapping());

            return new DriverManagementService(_driverRepository, mapper);
        }
    }

    
}