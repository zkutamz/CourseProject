using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// Configuration for LessonCompletion entity
    /// </summary>
    public class LessonCompletionConfiguration : IEntityTypeConfiguration<LessonCompletion>
    {
        public void Configure(EntityTypeBuilder<LessonCompletion> builder)
        {
            #region PropertiesConfig
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
            builder.Property(l => l.CompletedDate).IsRequired();
            #endregion


            #region RelationConfig
            builder.HasOne(l => l.Lession).WithMany(l => l.LessonCompletions).HasForeignKey(l => l.LessonId).OnDelete(DeleteBehavior.Cascade);          
            builder.HasOne(l => l.User).WithMany(u => u.LessonCompletions).HasForeignKey(l => l.UserId).OnDelete(DeleteBehavior.Cascade); 
            #endregion
        }
    }
}
