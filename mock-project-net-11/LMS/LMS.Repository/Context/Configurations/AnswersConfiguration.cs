using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// Configuration for Answers entity
    /// </summary>
    public class AnswersConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            #region PropertiesConfig
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Content).IsRequired();
            #endregion

            #region RelationConfig
            builder.HasOne(a => a.QuizQuestion).WithMany(q => q.Answers).HasForeignKey(a => a.QuizQuestionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.QuizSubmission).WithMany(q => q.Answers).HasForeignKey(a => a.QuizSubmissionId).OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
