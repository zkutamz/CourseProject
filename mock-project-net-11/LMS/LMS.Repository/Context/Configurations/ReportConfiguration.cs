using LMS.Repository.Entities;
using LMS.Repository.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// This class store configurations of Feedback domain class for fluent API
    /// </summary>
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            #region Property configurations
            builder.Property(r => r.Email)
                .HasColumnType("nvarchar(255)")
                .IsRequired();
            builder.Property(r => r.ScreenShot)
                .HasColumnType("nvarchar(255)")
                .HasDefaultValue(null);
            builder.Property(r => r.Description)
                .HasColumnType("nvarchar(4000)")
                .IsRequired();
            builder.Property(r => r.Answer)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
            builder.Property(r => r.Status)
                .HasDefaultValue(FeedbackStatus.Pending);
            builder.Property(f => f.UserId)
                .IsRequired();
            builder.HasQueryFilter(f => f.IsDelete == false);
            #endregion
            //#region Relationship configurations

            //builder.HasOne(r => r.User)
            //    .WithMany(u => u.Feedbacks)
            //    .HasForeignKey(c => c.UserId)
            //    .IsRequired();
            //#endregion
        }
    }
}
