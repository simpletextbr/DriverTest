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
    public class CreateDriver
    {

        [Fact]
        public async Task CreateDriver_Success(){
            // Arrange
            var service = Service();
            var viewModelFake = DriverViewModelFacker.GenerateDriverViewModel().Generate();

            // Act
            var result = await service.CreateDriver(viewModelFake);

            // Assert

            Assert.NotNull(result);
            Assert.Equal(viewModelFake.Name, result.Name);
            Assert.Equal(viewModelFake.DateOfBirth, result.DateOfBirth);
            Assert.Equal(viewModelFake.DrivingLicenseNumber, result.DrivingLicenseNumber);
            Assert.Equal(viewModelFake.DrivingLicenseExpirationDate, result.DrivingLicenseExpirationDate);
            Assert.Equal(viewModelFake.Email, result.Email);
            Assert.Equal(viewModelFake.City, result.City);
        }


        private static IDriverManagementService Service()
        {
            DbContextOptions<ApplicationContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("DriverManagmentService.Create");
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