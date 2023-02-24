using System;
using System.Collections.Generic;
using System.Text;
using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasKey(x => new {x.Id});
            //builder.HasOne(x => x.Lesson)
            //    .WithMany(x => x.Attachments)
            //    .HasForeignKey(x => x.LessonId);
            builder.HasOne(x => x.Assignment)
                .WithMany(x => x.Attachments)
                .HasForeignKey(x => x.AssignmentId);
        }
    }
}
