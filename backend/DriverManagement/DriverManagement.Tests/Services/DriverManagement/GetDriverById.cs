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
    public class GetDriverById
    {
        [Fact]
        public async Task GetDriversById_Success(){
            // Arrange
            var service = Service();
            var viewModelFake = DriverViewModelFacker.GenerateDriverViewModel().Generate();
            await service.CreateDriver(viewModelFake);

            // Act
            var result = await service.GetDriverById(viewModelFake.Id);
            // Assert

            Assert.Equal(viewModelFake.Name, result.Name);
            Assert.Equal(viewModelFake.DateOfBirth, result.DateOfBirth);
            Assert.Equal(viewModelFake.DrivingLicenseNumber, result.DrivingLicenseNumber);
            Assert.Equal(viewModelFake.DrivingLicenseExpirationDate, result.DrivingLicenseExpirationDate);
            Assert.Equal(viewModelFake.Email, result.Email);
            Assert.Equal(viewModelFake.City, result.City);
        }


        [Fact]
        public async Task GetDriversById_Not_Found(){
            // Arrange
            var service = Service();

            // Act
            var fakeId = Guid.NewGuid();
            // Assert

            await Assert.ThrowsAsync<Exception>(() => service.GetDriverById(fakeId));
        }


        private static IDriverManagementService Service()
        {
            DbContextOptions<ApplicationContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("DriverManagmentService.GetDriverById");
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