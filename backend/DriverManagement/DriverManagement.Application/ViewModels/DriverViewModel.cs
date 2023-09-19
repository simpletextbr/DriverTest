
namespace DriverManagement.Application.ViewModels
{
    public class DriverViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public DateTime DrivingLicenseExpirationDate { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}