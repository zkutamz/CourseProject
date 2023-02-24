using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Context.Configurations
{
    public partial class CourseDiscountConfiguration : IEntityTypeConfiguration<CourseDiscount>
    {
        public void Configure(EntityTypeBuilder<CourseDiscount> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.DiscountAmount).HasDefaultValue(0);
            builder.HasOne(p => p.Course)
                    .WithMany(p => p.CourseDiscounts)
                    .HasForeignKey(p => p.CourseId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired(false);
        }
    }
}
