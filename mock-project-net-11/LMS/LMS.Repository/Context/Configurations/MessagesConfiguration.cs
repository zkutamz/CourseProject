using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class MessagesConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            #region Properties
            // Id dentify
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            // Content not null
            builder.Property(c => c.Content).IsRequired();
            // IsRead not null
            builder.Property(c => c.IsRead).HasDefaultValue(false);
            #endregion

            #region Relationship
            // Realtionship one to one Message and Chat
            builder.HasOne(m => m.Chats).WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
