using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LMS.Repository.Context.Configurations
{
    public class UserLoginTokenConfiguration : IEntityTypeConfiguration<UserLoginToken>
    {
        public void Configure(EntityTypeBuilder<UserLoginToken> builder)
        {
            builder.HasOne(x => x.AppUser).WithMany(x => x.UserLoginTokens)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.Property(x => x.Token).IsRequired();
        }
    }
}
