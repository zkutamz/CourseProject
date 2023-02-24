using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// This class store configurations of Lesson domain class for fluent API
    /// </summary>
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            #region Property configurations

            builder.Property(s => s.Name)
                .HasColumnType("nvarchar(255)")
                .IsRequired();
            builder.Property(s => s.TotalTime)
                .IsRequired();

            builder.HasQueryFilter(s => s.IsDelete == false);

            #endregion

            #region Data Seeding

            //builder.HasData(
            //    new Section
            //    {
            //        Id = 1,
            //        Name = "Welcome to The Blender Encyclopedia",
            //        IsPublic = true,
            //        TotalTime = 360,
            //        CourseId = 1
            //    },
            //    new Section
            //    {
            //        Id = 2,
            //        Name = "Understanding Blender",
            //        IsPublic = true,
            //        TotalTime = 6510,
            //        CourseId = 1
            //    },
            //    new Section
            //    {
            //        Id = 3,
            //        Name = "Working with Blender",
            //        IsPublic = true,
            //        TotalTime = 10000,
            //        CourseId = 1
            //    });

            #endregion
        }
    }
}
