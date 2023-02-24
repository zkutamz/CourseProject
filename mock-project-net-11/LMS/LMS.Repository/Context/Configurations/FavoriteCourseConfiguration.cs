using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// Configuration for table FavoriteCourse
    /// </summary>
    public class FavoriteCourseConfiguration : IEntityTypeConfiguration<FavoriteCourse>
    {
        public void Configure(EntityTypeBuilder<FavoriteCourse> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.User)
                .WithMany(x => x.FavoriteCourses)
                .HasForeignKey(x => x.UserId)
                ;

            builder.HasOne(x => x.Course)
                .WithMany(x => x.FavoriteCourses)
                .HasForeignKey(x => x.CourseId)
                ;

            builder.HasQueryFilter(n => n.IsDelete == false);
        }
    }
}
