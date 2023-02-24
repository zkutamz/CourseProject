using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// This class store configurations of Lesson domain class for fluent API
    /// </summary>
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            #region Property configurations
            builder.Property(l => l.Title).HasColumnType("nvarchar(255)").IsRequired();
            builder.Property(l => l.Content).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(l => l.TotalTime).IsRequired();
            builder.HasQueryFilter(l => l.IsDelete == false);

            #endregion

            #region Relationship configurations

            builder.HasOne(l => l.Section)
                .WithMany(s => s.Lessons)
                .HasForeignKey(l => l.SectionId)
                .IsRequired();

            #endregion

            #region Data Seeding

            //builder.HasData(
            //    new Lesson
            //    {
            //        Id = 1,
            //        Title = "Introduction: Your Own Blender Encyclopedia",
            //        Content =
            //            "Both Christopher Plush, and myself Lee Salvemini want to welcome you to the Blender 2.8 Encyclopedia! " +
            //            "You've made the right choice, and we hope you enjoy this combined learning path/reference guide." +
            //            "Blender, is the 3D software package we've chosen for the Encyclopedia. A completely Free and Open Source creation suite. Download your copy now at blender.org. " +
            //            "With no license or fees, you can install it anywhere, and get started right away!",
            //        TotalTime = 360,
            //        IsPublic = true,
            //        SectionId = 1
            //    },
            //    new Lesson
            //    {
            //        Id = 2,
            //        Title = "Navigating the Course (Important!)",
            //        Content = "Just a few notes on navigating all of this material to help you learn from it more effectively.",
            //        TotalTime = 139,
            //        IsPublic = true,
            //        SectionId = 1
            //    },
            //    new Lesson
            //    {
            //        Id = 3,
            //        Title = "User Interface",
            //        Content = "Get to know the software by first taking a tour of everything you see when we first open up Blender." +
            //                  " See how Blender organizes it's areas, headers, and toolbars in this casual start to learning about the program.",
            //        TotalTime = 249,
            //        IsPublic = true,
            //        SectionId = 2
            //    });

            #endregion
        }
    }
}
