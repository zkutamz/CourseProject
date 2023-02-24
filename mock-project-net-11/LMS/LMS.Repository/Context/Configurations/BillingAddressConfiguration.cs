using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class BillingAddressConfiguration : IEntityTypeConfiguration<BillingAddress>
    {
        public void Configure(EntityTypeBuilder<BillingAddress> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.LastName)
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.FirstName)
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.AcademyName)
                .HasColumnType("nvarchar(255)");

            builder.Property(x => x.Country)
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.AddressLine1)
                .HasColumnType("nvarchar(255)");

            builder.Property(x => x.AddressLine2)
                .HasColumnType("nvarchar(255)");

            builder.Property(x => x.City)
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.Province)
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("varchar(20)");

            builder.Property(x => x.EmailPaypal)
                .HasColumnType("varchar(255)");

            builder.HasOne(x => x.WithdrawalMethod)
                .WithMany(x => x.BillingAddresses)
                .HasForeignKey(x => x.WithdrawalMethodId);

            builder.HasOne(x => x.User)
                .WithOne(x => x.BillingAddress)
                .HasForeignKey<BillingAddress>(x => x.UserId);
        }
    }
}
