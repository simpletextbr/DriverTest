using System.ComponentModel.DataAnnotations;

namespace DriverManagement.Domain.Models
{
    public class DriverModel : BaseModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Driving License Number")]
        public string DrivingLicenseNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Driving License Expiration Date")]
        public DateTime DrivingLicenseExpirationDate { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

    }
}