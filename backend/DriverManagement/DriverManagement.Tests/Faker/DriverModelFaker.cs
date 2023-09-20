using Bogus;
using DriverManagement.Domain.Models;

namespace DriverManagement.Tests.Faker
{
    public class DriverModelFacker
    {
        public static Faker<DriverModel> GenerateDriverModel()
        {
            var driverFaker = new Faker<DriverModel>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.DateOfBirth, f => f.Date.Past())
                .RuleFor(x => x.DrivingLicenseNumber, f => f.Random.String2(10))
                .RuleFor(x => x.DrivingLicenseExpirationDate, f => f.Date.Future())
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.City, f => f.Address.City())
                .RuleFor(x => x.CreatedAt, f => f.Date.Past())
                .RuleFor(x => x.UpdatedAt, f => f.Date.Past());

            return driverFaker;
        }

        public static List<Faker<DriverModel>> GenerateDriverModelList(){
            var driverFakerList = new List<Faker<DriverModel>>();

            for (int i = 0; i <= 3; i++)
            {
                var driverFaker = GenerateDriverModel();
                driverFakerList.Add(driverFaker);
            }

            return driverFakerList;
        }
    }
}
