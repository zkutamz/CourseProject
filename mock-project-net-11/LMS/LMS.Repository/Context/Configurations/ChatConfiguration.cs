using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            #region Properties
            // Id dentify
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.IsBlock).HasDefaultValue(false);
            builder.Property(c => c.IsDelete).HasDefaultValue(false);
            builder.HasQueryFilter(c => c.IsDelete == false);
            #endregion
        }
    }
}
