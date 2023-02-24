using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.HasOne(c => c.OrderHeader)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(c => c.OrderHeaderId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(c => c.Course)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}