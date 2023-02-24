using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class OrderHeaderConfiguration : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.OrderTotal).HasColumnType("money");

            builder.HasOne(c => c.User)
                .WithMany(s => s.OrderHeaders)
                .HasForeignKey(c => c.SessionId)
                .IsRequired();

            builder.HasOne(c => c.PaymentMethods)
                .WithMany(s => s.OrderHeaders)
                .HasForeignKey(c => c.PaymentMethodId)
                .IsRequired();
        }
    }
}