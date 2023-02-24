using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class QuizQuestionConfiguration : IEntityTypeConfiguration<QuizQuestion>
    {
        public void Configure(EntityTypeBuilder<QuizQuestion> builder)
        {
            #region PropertiesConfiguration
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Title)
                .HasColumnType("nvarchar(255)");
            builder.Property(x => x.OptionA)
                .HasColumnType("nvarchar(255)");
            builder.Property(x => x.OptionB)
                .HasColumnType("nvarchar(255)");
            builder.Property(x => x.OptionC)
                .HasColumnType("nvarchar(255)");
            builder.Property(x => x.OptionD)
                .HasColumnType("nvarchar(255)");
            builder.Property(x => x.Answer)
                .HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.Explanation)
                .HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.IsDelete)
                .HasDefaultValue(false);
            builder.Property(x => x.IsPublic)
                .HasDefaultValue(false);
            builder.HasQueryFilter(c => c.IsDelete == false);
            #endregion
            #region RelationshipConfiguration
            builder.HasMany(x => x.Answers)
                .WithOne(x => x.QuizQuestion)
                .HasForeignKey(x => x.QuizQuestionId);
            #endregion

            #region Data Seeding

            //builder.HasData(
            //    new QuizQuestion
            //    {
            //        Id = 1,
            //        Title = "What are the hotkeys for rotating, zooming, and panning your scene?",
            //        OptionA = "Left click for rotating, Shift + Left Click for zooming, and Alt + Left Click for panning",
            //        OptionB = "Right click for rotating, Shift + Right Click for zooming, and Alt + Right Click for panning",
            //        OptionC = "Middle click for rotating, Shift + Middle Click for zooming, and Alt + Middle Click for panning",
            //        OptionD = "None of the above",
            //        Answer = "Middle click for rotating, Shift + Middle Click for zooming, and Alt + Middle Click for panning",
            //        Explanation = "Some explanation",
            //        IsPublic = true,
            //        QuizId = 1
            //    },
            //    new QuizQuestion
            //    {
            //        Id = 2,
            //        Title = "Which super important add-on do I suggest enabling for help creating shaders?",
            //        OptionA = "IvyGen",
            //        OptionB = "Node Wrangler",
            //        OptionC = "Animation Nodes",
            //        OptionD = "None of the above",
            //        Answer = "Animation Nodes",
            //        Explanation = "Some explanation",
            //        IsPublic = true,
            //        QuizId = 1
            //    });

            #endregion
        }
    }

}
