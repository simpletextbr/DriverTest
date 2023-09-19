using DriverManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriverManagement.Infrastructure.Configurations
{
    public class DriverConfigurarion : IEntityTypeConfiguration<DriverModel>
    {
        public void Configure(EntityTypeBuilder<DriverModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Name)
            .HasColumnName("name");

            builder.Property(x => x.DateOfBirth)
            .HasColumnName("date_of_birth");

            builder.Property(x => x.DrivingLicenseNumber)
            .HasColumnName("driving_license_number");

            builder.Property(x => x.DrivingLicenseExpirationDate)
            .HasColumnName("driving_license_expiration_date");

            builder.Property(x => x.Email)
            .HasColumnName("email");

            builder.Property(x => x.City)
            .HasColumnName("city");


            builder.ToTable("drivers", schema: "drivers_management");
        }
    }
}