using System;
using System.Collections.Generic;
using System.Text;
using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class VisitorConfiguration : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Course)
                .WithMany(x => x.Visitors)
                .HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Visitors)
                .HasForeignKey(x => x.UserId);
        }
    }
}
