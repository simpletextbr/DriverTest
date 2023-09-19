namespace DriverManagement.Domain.Models
{
    public class DriverModel : BaseModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public DateTime DrivingLicenseExpirationDate { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

    }
}