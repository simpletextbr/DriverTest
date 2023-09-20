using DriverManagement.Domain;
using DriverManagement.Domain.Models;
using DriverManagement.Infrasctructure.Repositories;
using DriverManagement.Infrastructure.Context;
using DriverManagement.Tests.Faker;
using Microsoft.EntityFrameworkCore;

namespace DriverManagement.Tests.Repositories.Base
{
    public class Delete
    {
        [Fact]
        public async Task Delete_Success()
        {
            // Arrange
            var repository = Repository();

            var modelFake = DriverModelFacker.GenerateDriverModel().Generate();
            var modelFakeToBeDelete = DriverModelFacker.GenerateDriverModel().Generate();
            await repository.Create(modelFake);
            await repository.Create(modelFakeToBeDelete);

            var driver = await repository.GetAll();

            Assert.Equal(2, driver.Count());

            // Act
            await repository.Delete(modelFakeToBeDelete.Id);
            var result = await repository.GetAll();
            // Assert
            Assert.Equal(1, result.Count());
            
        }

        private static IBaseRepository<DriverModel> Repository()
        {
            DbContextOptions<ApplicationContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("BaseRepository.Delete");
            options = builder.Options;
            var context = new ApplicationContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return new BaseRepository<DriverModel>(context);
        }
    }
}