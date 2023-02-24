using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// Configuration for Notification entity
    /// </summary>
    public class NotificationsConfiguration : IEntityTypeConfiguration<Notifications>
    {
        public void Configure(EntityTypeBuilder<Notifications> builder)
        {
            #region PropertiesConfig
            builder.Property(n => n.Id).ValueGeneratedOnAdd();
            builder.Property(n => n.Details).IsRequired();
            builder.Property(n => n.Message).IsRequired().HasMaxLength(100);
            #endregion

            #region RelationConfig
            builder.HasOne(n => n.User).WithMany(u => u.Notifications).HasForeignKey(n => n.UserId).OnDelete(DeleteBehavior.Cascade); 
            #endregion
        }
    }
}
