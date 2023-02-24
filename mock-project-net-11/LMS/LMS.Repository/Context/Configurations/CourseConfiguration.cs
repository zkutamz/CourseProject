using LMS.Repository.Entities;
using LMS.Repository.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// This class store configurations of Lesson domain class for fluent API
    /// </summary>
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            #region Property configurations

            builder.HasIndex(l => l.Title)
                .IsUnique();
            builder.Property(l => l.Title)
                .HasColumnType("nvarchar(255)")
                .IsRequired();
            builder.Property(l => l.Requirement)
                .HasColumnType("nvarchar(4000)")
                .IsRequired();
            builder.Property(l => l.Price)
                .HasColumnType("money")
                .IsRequired();
            builder.Property(l => l.OriginalPrice)
                .HasColumnType("money")
                .IsRequired();
            builder.Property(l => l.TotalDuration)
                .IsRequired();
            builder.Property(l => l.CourseStatus)
                .HasDefaultValue(CourseStatus.Draft);
            builder.Property(l => l.ShortDescription)
                .HasColumnType("nvarchar(220)")
                .IsRequired();
            builder.Property(l => l.Description)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
            builder.Property(l => l.WhatLearn)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
            builder.Property(l => l.Level)
                .IsRequired();
            builder.Property(l => l.AudioLanguage)
                .IsRequired();
            builder.Property(l => l.CloseCaption)
                .IsRequired();
            builder.HasQueryFilter(c => c.IsDelete == false);
            #endregion

            #region Relationship configurations

            builder.HasMany(c => c.Sections)
                .WithOne(s => s.Course)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(c => c.AppUser)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(c => c.Category)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            #endregion

            #region Data Seeding

            builder.HasData(
                new Course
                {
                    Id = 1,
                    Title = "The Blender 2.8 Encyclopedia Version 1",
                    Description = "Welcome to The Blender Encyclopedia, the most comprehensive training course available for Blender, a completely free and open source 3D production suite." +
                                  "Our aim with the course was to make an expanded version of the Blender Manual, that you can follow along or reference at any time in your 3D journey." +
                                  "Further than the tools alone, we've made sure this course contains not just the how, but the why. Throughout the course, we've crafted example demos, as well as step by step projects," +
                                  "that will take what you've learned and form it into a practical example. You can get all the Blender files used in the lectures, complete with models," +
                                  "textures and other resources.This includes starting files so you can join in!You can use these resource files in your own projects as well.Just open them up to see their license details, if any." +
                                  "We have created this course specifically for Udemy, and you will have unlimited support from us in the Q & A section of each lecture.See you in the course, and happy blending!",
                    Price = 49,
                    OriginalPrice = 49,
                    ThumbNailUrl = "blender.jpg",
                    PublishedDate = new DateTime(2022, 01, 01),
                    Requirement = "Blender 2.8 or Blender 2.9",
                    Feature = false,
                    TotalDuration = 165600,
                    Level = Level.Beginner,
                    CourseStatus = CourseStatus.Active,
                    InstructorId = 3,
                    CategoryId = 2,
                    ShortDescription = "Welcome to The Blender Encyclopedia",
                    AudioLanguage = "English",
                    WhatLearn = "Nothing",
                    CloseCaption = "English"
                },
                 new Course
                 {
                     Id = 2,
                     Title = "The Blender 2.8 Encyclopedia V2",
                     Description = "Welcome to The Blender Encyclopedia, the most comprehensive training course available for Blender, a completely free and open source 3D production suite." +
                                  "Our aim with the course was to make an expanded version of the Blender Manual, that you can follow along or reference at any time in your 3D journey." +
                                  "Further than the tools alone, we've made sure this course contains not just the how, but the why. Throughout the course, we've crafted example demos, as well as step by step projects," +
                                  "that will take what you've learned and form it into a practical example. You can get all the Blender files used in the lectures, complete with models," +
                                  "textures and other resources.This includes starting files so you can join in!You can use these resource files in your own projects as well.Just open them up to see their license details, if any." +
                                  "We have created this course specifically for Udemy, and you will have unlimited support from us in the Q & A section of each lecture.See you in the course, and happy blending!",
                     Price = 49,
                     OriginalPrice = 49,
                     ThumbNailUrl = "blender.jpg",
                     PublishedDate = new DateTime(2022, 01, 01),
                     Requirement = "Blender 2.8 or Blender 2.9",
                     Feature = false,
                     TotalDuration = 165600,
                     Level = Level.Beginner,
                     CourseStatus = CourseStatus.Active,
                     InstructorId = 3,
                     CategoryId = 2,
                     ShortDescription = "Welcome to The Blender Encyclopedia",
                     AudioLanguage = "English",
                     WhatLearn = "Nothing",
                     CloseCaption = "English"
                 });

            #endregion
        }
    }
}
