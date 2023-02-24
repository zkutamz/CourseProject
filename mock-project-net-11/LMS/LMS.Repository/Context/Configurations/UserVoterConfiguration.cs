using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class UserVoterConfiguration : IEntityTypeConfiguration<UserVoter>
    {
        public void Configure(EntityTypeBuilder<UserVoter> builder)
        {
            builder.HasKey(u => new
            {
                u.UserId,
                u.VoterId
            });

            builder.HasOne(u => u.AppUser)
                .WithMany(a => a.UserVoters)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
