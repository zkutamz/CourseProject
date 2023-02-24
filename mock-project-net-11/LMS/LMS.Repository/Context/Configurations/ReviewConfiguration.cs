using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// This class store configurations of Review domain class for fluent API
    /// </summary>
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            #region Property configurations

            builder.Property(n => n.Content).IsRequired();
            builder.Property(n => n.Rating).IsRequired();
            builder.Property(n => n.HelpfulnessRating).HasDefaultValue(0);
            builder.HasQueryFilter(r => r.IsDelete == false);

            builder.HasQueryFilter(s => s.IsDelete == false);

            #endregion
        }
    }
}