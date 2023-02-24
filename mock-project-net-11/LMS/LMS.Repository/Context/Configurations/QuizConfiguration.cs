using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            #region PropertiesConfiguration
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("nvarchar(255)");
            builder.Property(x => x.ImgUrl)
                .HasMaxLength(255);
            builder.Property(x => x.Content)
                .HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.ImgUrl)
                .HasColumnType("nvarchar(255)");
            builder.Property(x => x.IsDelete)
                .HasDefaultValue(false);
            builder.Property(x => x.IsPublic)
                .HasDefaultValue(false);
            builder.HasQueryFilter(c => c.IsDelete == false);
            #endregion
            #region RelationshipConfiguration
            builder.HasMany(x => x.QuizSubmissions)
                .WithOne(x => x.Quiz)
                .HasForeignKey(x => x.QuizId);

            builder.HasMany(x => x.QuizQuestions)
                .WithOne(x => x.Quiz)
                .HasForeignKey(x => x.QuizId);

            #endregion

            #region Data Seeding

            //builder.HasData(
            //    new Quiz
            //    {
            //        Id = 1,
            //        Title = "How much do you know about Blender so far?",
            //        Content = "Content",
            //        TotalTime = 240,
            //        IsPublic = true,
            //        IsExposedQuestion = false,
            //       // SectionId = 2
            //    });

            #endregion
        }
    }
}
