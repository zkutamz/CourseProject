using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Context.Configurations
{
    public class CoursePromotionConfiguration : IEntityTypeConfiguration<CoursePromotion>
    {
        public void Configure(EntityTypeBuilder<CoursePromotion> builder)
        {
            builder.HasKey(p=>p.Id);
            builder.Property(p => p.CouponCode).IsRequired().HasMaxLength(8);
            builder.HasIndex(p => p.CouponCode);
            builder.HasMany(p=>p.OrderHeaders)
                .WithOne(p => p.CoursePromotion)
                .HasForeignKey(p => p.CouponCode)
                .IsRequired(false);
            builder.HasOne(p => p.Vendor)
                .WithMany(p => p.CoursePromotions)
                .HasForeignKey(p => p.VendorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
