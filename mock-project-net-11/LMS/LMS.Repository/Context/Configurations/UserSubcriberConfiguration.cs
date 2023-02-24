using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class UserSubcriberConfiguration : IEntityTypeConfiguration<UserSubcriber>
    {
        public void Configure(EntityTypeBuilder<UserSubcriber> builder)
        {
            builder.HasKey(s => new { s.SubcriberId, s.UserId });

            builder.HasOne(s => s.User)
                .WithMany(s => s.UserSubscribeds)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Subscriber)
                .WithMany(a => a.InstructorSubscribeds)
                .HasForeignKey(s => s.SubcriberId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
