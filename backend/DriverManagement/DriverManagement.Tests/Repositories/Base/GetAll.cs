using DriverManagement.Domain;
using DriverManagement.Domain.Models;
using DriverManagement.Infrasctructure.Repositories;
using DriverManagement.Infrastructure.Context;
using DriverManagement.Tests.Faker;
using Microsoft.EntityFrameworkCore;

namespace DriverManagement.Tests.Repositories.Base
{
    public class GetAll
    {
        [Fact]
        public async Task GetAll_Success()
        {
            // Arrange
            var repository = Repository();

            var modelFake = DriverModelFacker.GenerateDriverModelList();

            // Act
            var driverModelMock = await repository.Create(modelFake[0]);
            var driverModelMock1 = await repository.Create(modelFake[1]);
            var driverModelMock2 = await repository.Create(modelFake[2]);
            var driverModelMock3 = await repository.Create(modelFake[3]);
            

            var driver = await repository.GetAll();

            // Assert
            Assert.Equal(4, driver.Count());
            Assert.Equal(driver[0].Name, driverModelMock.Name);
            Assert.Equal(driver[0].Email, driverModelMock.Email);
            Assert.Equal(driver[0].City, driverModelMock.City);
            Assert.Equal(driver[1].Name, driverModelMock1.Name);
            Assert.Equal(driver[1].Email, driverModelMock1.Email);
            Assert.Equal(driver[1].City, driverModelMock1.City);
            Assert.Equal(driver[2].Name, driverModelMock2.Name);
            Assert.Equal(driver[2].Email, driverModelMock2.Email);
            Assert.Equal(driver[2].City, driverModelMock2.City);
            Assert.Equal(driver[3].Name, driverModelMock3.Name);
            Assert.Equal(driver[3].Email, driverModelMock3.Email);
            Assert.Equal(driver[3].City, driverModelMock3.City);

        }


        private static IBaseRepository<DriverModel> Repository()
        {
            DbContextOptions<ApplicationContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("BaseRepository.GetAll");
            options = builder.Options;
            var context = new ApplicationContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return new BaseRepository<DriverModel>(context);
        }

    }
}