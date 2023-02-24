using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// Configuration for table CourseComment
    /// </summary>
    public class CourseCommentConfiguration : IEntityTypeConfiguration<CourseComment>
    {
        public void Configure(EntityTypeBuilder<CourseComment> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.User)
                .WithOne(x => x.CourseComment)
                .HasForeignKey<CourseComment>(x => x.UserId)
                ;

            builder.HasOne(x => x.ParentComment)
                .WithMany(x => x.ChildCourseComments)
                .HasForeignKey(x => x.ParentCommentId);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.CourseComments)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
