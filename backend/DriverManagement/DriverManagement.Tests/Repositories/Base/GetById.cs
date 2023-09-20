using DriverManagement.Domain;
using DriverManagement.Domain.Models;
using DriverManagement.Infrasctructure.Repositories;
using DriverManagement.Infrastructure.Context;
using DriverManagement.Tests.Faker;
using Microsoft.EntityFrameworkCore;

namespace DriverManagement.Tests.Repositories.Base
{
    public class GetById
    {
        [Fact]
        public async Task GetById_Success()
        {
            // Arrange
            var repository = Repository();

            var modelFake = DriverModelFacker.GenerateDriverModel().Generate();

            // Act
            await repository.Create(modelFake);

            var driver = await repository.GetById(modelFake.Id);

            // Assert
            Assert.Equal(modelFake.Name, driver.Name);
            Assert.Equal(modelFake.Email, driver.Email);
            Assert.Equal(modelFake.City, driver.City);
            Assert.Equal(modelFake.DrivingLicenseNumber, driver.DrivingLicenseNumber);
            Assert.Equal(modelFake.DrivingLicenseExpirationDate, driver.DrivingLicenseExpirationDate);
            Assert.Equal(modelFake.DateOfBirth, driver.DateOfBirth);
        }

        private static IBaseRepository<DriverModel> Repository()
        {
            DbContextOptions<ApplicationContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("BaseRepository.GetById");
            options = builder.Options;
            var context = new ApplicationContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return new BaseRepository<DriverModel>(context);
        }
    }
}