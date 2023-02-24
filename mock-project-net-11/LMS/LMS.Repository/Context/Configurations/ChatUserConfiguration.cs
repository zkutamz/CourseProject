using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class ChatUserConfiguration : IEntityTypeConfiguration<ChatUser>
    {
        public void Configure(EntityTypeBuilder<ChatUser> builder)
        {
            #region Properties
            builder.HasKey(c => new { c.ChatId, c.UserId });
            builder.Property(cu => cu.IsMute).HasDefaultValue(false);
            builder.HasQueryFilter(cu => cu.Chat.IsDelete == false && cu.User.IsDelete == false);
            #endregion

            #region Relationship
            builder.HasOne(cu => cu.Chat).WithMany(c => c.ChatUsers)
                    .HasForeignKey(cu => cu.ChatId)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(cu => cu.User).WithMany(u => u.ChatUser)
                .HasForeignKey(cu => cu.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
            #endregion
        }
    }
}
