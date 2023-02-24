using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.HasKey(x => new { x.DiscussionId, x.UserId });

            builder.HasOne(x => x.Discussion)
                .WithMany(x => x.Reactions)
                .HasForeignKey(x => x.DiscussionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reactions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
