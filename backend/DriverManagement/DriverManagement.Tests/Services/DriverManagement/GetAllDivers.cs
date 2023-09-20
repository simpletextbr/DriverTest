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
    public class GetAllDivers
    {
        [Fact]
        public async Task GetAllDrivers_Success(){
            // Arrange
            var service = Service();
            var viewModelFake = DriverViewModelFacker.GenerateDriverViewModel().Generate();
            var viewModelFake2 = DriverViewModelFacker.GenerateDriverViewModel().Generate();
            await service.CreateDriver(viewModelFake);
            await service.CreateDriver(viewModelFake2);

            // Act
            var result = await service.GetAllDrivers();
            // Assert

            Assert.Equal(2, result.Count);
            Assert.Equal(viewModelFake.Name, result[0].Name);
            Assert.Equal(viewModelFake.DateOfBirth, result[0].DateOfBirth);
            Assert.Equal(viewModelFake.DrivingLicenseNumber, result[0].DrivingLicenseNumber);
            Assert.Equal(viewModelFake.DrivingLicenseExpirationDate, result[0].DrivingLicenseExpirationDate);
            Assert.Equal(viewModelFake.Email, result[0].Email);
            Assert.Equal(viewModelFake.City, result[0].City);
            Assert.Equal(viewModelFake2.Name, result[1].Name);
            Assert.Equal(viewModelFake2.DateOfBirth, result[1].DateOfBirth);
            Assert.Equal(viewModelFake2.DrivingLicenseNumber, result[1].DrivingLicenseNumber);
            Assert.Equal(viewModelFake2.DrivingLicenseExpirationDate, result[1].DrivingLicenseExpirationDate);
            Assert.Equal(viewModelFake2.Email, result[1].Email);
            Assert.Equal(viewModelFake2.City, result[1].City);
        }


        private static IDriverManagementService Service()
        {
            DbContextOptions<ApplicationContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("DriverManagmentService.GetAll");
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