using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Context.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(p=> new {p.UserId, p.CourseId});
            builder.HasOne(p=>p.AppUser)
                .WithMany(p=>p.ShoppingCarts)
                .HasForeignKey(p=>p.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Course)
                .WithMany(p => p.ShoppingCarts)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(p=>p.Created).HasDefaultValue(DateTime.Now);
        }
    }
}
