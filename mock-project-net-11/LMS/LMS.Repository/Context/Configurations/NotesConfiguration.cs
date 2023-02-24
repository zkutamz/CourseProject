using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// This class store configurations of Notes domain class for fluent API
    /// </summary>
    public class NotesConfiguration : IEntityTypeConfiguration<Notes>
    {
        public void Configure(EntityTypeBuilder<Notes> builder)
        {
            #region Property configurations
            builder.Property(n => n.Content).IsRequired();
            builder.HasQueryFilter(n => n.IsDelete == false);
            #endregion
            #region Relationship configurations
            builder.HasOne<EnrollCourse>(n => n.EnrollCourse)
                    .WithMany(ec => ec.Notes)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasForeignKey(n => n.EnrollCourseId)
                    .IsRequired();
            builder.HasOne<Lesson>(n => n.Lesson)
                   .WithMany(l => l.Notes)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(n => n.LessonId)
                   .IsRequired();
            #endregion
        }
    }
}
