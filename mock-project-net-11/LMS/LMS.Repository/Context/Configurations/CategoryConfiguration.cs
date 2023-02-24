using System;
using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            #region Property configurations

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnType("nvarchar(255)").IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.HasOne(x => x.ParentCategory)
                .WithMany(x => x.ChildCategories)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            #endregion

            #region Data Seeding

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Development",
                    Icon = "BsCode",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 2,
                    Name = "Business",
                    Icon = "BsBarChart",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 3,
                    Name = "Finance & Accounting",
                    Icon = "AiOutlineAccountBook",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 4,
                    Name = "IT & Software",
                    Icon = "HiOutlineDesktopComputer",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 5,
                    Name = "Office Productivity",
                    Icon = "HiOutlineOfficeBuilding",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 6,
                    Name = "Personal Development",
                    Icon = "AiOutlineBook",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 7,
                    Name = "Design",
                    Icon = "RiRulerLine",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 8,
                    Name = "Marketing",
                    Icon = "AiOutlineBarChart",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 9,
                    Name = "Lifestyle",
                    Icon = "GiLifeInTheBalance",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 10,
                    Name = "Photography",
                    Icon = "MdOutlinePhotoCamera",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 11,
                    Name = "Health & Fitness",
                    Icon = "IoFitnessOutline",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 12,
                    Name = "Music",
                    Icon = "IoMusicalNotesOutline",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 13,
                    Name = "Teaching & Academics",
                    Icon = "HiOutlineAcademicCap",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

            #endregion
        }
    }
}