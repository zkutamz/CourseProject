using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// This class store configurations of Lesson domain class for fluent API
    /// </summary>
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            #region Property configurations
            builder.HasQueryFilter(c => c.IsDelete == false);


            #endregion

            #region Relationship configurations

            builder.HasOne(b => b.Section)
                .WithMany(s => s.Assignments)
                .HasForeignKey(a => a.SectionId);

            #endregion

            #region Data Seeding

            //builder.HasData(
            //    new Assignment
            //    {
            //        Id = 1,
            //        Title = "Test Assignment",
            //        Content = "Assignment content",
            //        IsAutoMarking = false,
            //        SectionId = 1,
            //        TotalTime = 300
            //    });

            #endregion
        }
    }
}
