using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class QuizSubmissionConfiguration : IEntityTypeConfiguration<QuizSubmission>
    {
        public void Configure(EntityTypeBuilder<QuizSubmission> builder)
        {
            #region PropertiesConfiguration
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder.Property(x => x.IsCompleted)
                .HasDefaultValue(false);
            builder.Property(x => x.IsDelete)
                .HasDefaultValue(false);
            #endregion
            #region RelationshipConfiguration
            builder.HasMany(x => x.Answers)
                .WithOne(x => x.QuizSubmission)
                .HasForeignKey(x => x.QuizSubmissionId);
            #endregion
        }
    }
}
