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
    public class UpdateDriver
    {
        [Fact]
        public async Task UpdateDriver_Success(){
            // Arrange
            var service = Service();
            var viewModelFake = DriverViewModelFacker.GenerateDriverViewModel().Generate();
            await service.CreateDriver(viewModelFake);
            viewModelFake.Name = "Teste";
            viewModelFake.DrivingLicenseNumber = "123123123";
            viewModelFake.Email = "teste@testado.com.br";
            viewModelFake.City = "Teste City";
            
            // Act
            var result = await service.UpdateDriver(viewModelFake);

            // Assert
            Assert.Equal("Teste", result.Name);
            Assert.Equal("123123123", result.DrivingLicenseNumber);
            Assert.Equal("teste@testado.com.br", result.Email);
            Assert.Equal("Teste City", result.City);
        }


        [Fact]
        public async Task UpdateDriver_Failed(){
            // Arrange
            var service = Service();

            // Act
             var viewModelFake = DriverViewModelFacker.GenerateDriverViewModel().Generate();
            // Assert

            await Assert.ThrowsAsync<Exception>(() => service.UpdateDriver(viewModelFake));
        }


        private static IDriverManagementService Service()
        {
            DbContextOptions<ApplicationContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("DriverManagmentService.UpdateDriver");
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