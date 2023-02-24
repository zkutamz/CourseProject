using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class DiscussionConfiguration : IEntityTypeConfiguration<Discussion>
    {
        public void Configure(EntityTypeBuilder<Discussion> builder)
        {
            builder.Property(x => x.Content)
                .HasColumnType("nvarchar(max)")
                .IsRequired()
                .HasDefaultValue(string.Empty);

            builder.HasQueryFilter(x => x.IsDelete == false);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Discussions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ParentDiscussions)
                .WithMany(x => x.ChildDiscussions)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
