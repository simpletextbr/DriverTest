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
            .IsRequired()
            .HasColumnName("name");

            builder.Property(x => x.DateOfBirth)
            .IsRequired()
            .HasColumnName("date_of_birth");

            builder.Property(x => x.DrivingLicenseNumber)
            .IsRequired()
            .HasColumnName("driving_license_number");

            builder.Property(x => x.DrivingLicenseExpirationDate)
            .IsRequired()
            .HasColumnName("driving_license_expiration_date");

            builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("email");

            builder.Property(x => x.City)
            .IsRequired()
            .HasColumnName("city");


            builder.ToTable("Drivers", schema: "drivers_management");
        }
    }
}