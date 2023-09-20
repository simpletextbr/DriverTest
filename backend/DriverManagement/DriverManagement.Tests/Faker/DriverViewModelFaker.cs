using Bogus;
using DriverManagement.Application.ViewModels;
using DriverManagement.Domain.Models;

namespace DriverManagement.Tests.Faker
{
    public class DriverViewModelFacker
    {
        public static Faker<DriverViewModel> GenerateDriverViewModel()
        {
            var driverFaker = new Faker<DriverViewModel>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.DateOfBirth, f => f.Date.Past())
                .RuleFor(x => x.DrivingLicenseNumber, f => f.Random.String2(10))
                .RuleFor(x => x.DrivingLicenseExpirationDate, f => f.Date.Future())
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.City, f => f.Address.City());

            return driverFaker;
        }

        public static List<Faker<DriverViewModel>> GenerateDriverViewModelList(){
            var driverFakerList = new List<Faker<DriverViewModel>>();

            for (int i = 0; i <= 3; i++)
            {
                var driverFaker = GenerateDriverViewModel();
                driverFakerList.Add(driverFaker);
            }

            return driverFakerList;
        }
    }
}
