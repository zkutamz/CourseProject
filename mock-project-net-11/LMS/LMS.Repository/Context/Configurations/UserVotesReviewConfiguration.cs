using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class UserVotesReviewConfiguration : IEntityTypeConfiguration<UserVotesReview>
    {
        public void Configure(EntityTypeBuilder<UserVotesReview> builder)
        {
            #region Model configurations

            builder.HasIndex(u => new
            {
                u.UserId,
                u.ReviewId
            }).IsUnique(true);

            #endregion

            #region Relationship configurations

            builder.HasOne(u => u.Review)
                .WithMany(r => r.UserVotesReviews)
                .HasForeignKey(u => u.ReviewId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.User)
                .WithMany(au => au.UserVotesReviews)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion
        }
    }
}
