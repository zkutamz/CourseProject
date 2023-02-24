using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// Configuration for LearningPeriods entity
    /// </summary>
    public class LearningPeriodsConfiguration : IEntityTypeConfiguration<LearningPeriods>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LearningPeriods> builder)
        {
            #region PropertiesConfig
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
            builder.Property(l => l.LearningDate).IsRequired();
            builder.Property(l => l.Period).HasDefaultValue(0);
            #endregion

            #region RelationConfig
            builder.HasOne(l => l.User).WithMany(u => u.LearningPeriods).HasForeignKey(l => l.UserId).OnDelete(DeleteBehavior.Cascade); 
            #endregion
        }
    }
}
