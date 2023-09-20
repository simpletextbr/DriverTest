using DriverManagement.Domain;
using DriverManagement.Domain.Models;
using DriverManagement.Infrasctructure.Repositories;
using DriverManagement.Infrastructure.Context;
using DriverManagement.Tests.Faker;
using Microsoft.EntityFrameworkCore;
namespace DriverManagement.Tests.Repositories.Base
{
    public class Update
    {
        [Fact]
        public async Task Update_Success()
        {
            // Arrange
            var repository = Repository();

            var modelFake = DriverModelFacker.GenerateDriverModel().Generate();

            await repository.Create(modelFake);
            // Act
            modelFake.Name = "Teste";
            modelFake.Email = "test@testato.com.br";
            modelFake.City = "Teste";

            var driver = await repository.Update(modelFake);

            // Assert
            Assert.Equal("Teste", driver.Name);
            Assert.Equal("test@testato.com.br", driver.Email);
            Assert.Equal("Teste", driver.City);

        }

        private static IBaseRepository<DriverModel> Repository()
        {
            DbContextOptions<ApplicationContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("BaseRepository.Update");
            options = builder.Options;
            var context = new ApplicationContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return new BaseRepository<DriverModel>(context);
        }
    }
}