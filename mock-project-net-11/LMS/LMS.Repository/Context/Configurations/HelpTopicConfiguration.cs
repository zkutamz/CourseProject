using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class HelpTopicConfiguration : IEntityTypeConfiguration<HelpTopic>
    {
        public void Configure(EntityTypeBuilder<HelpTopic> builder)
        {
            #region Property Configuration
            builder.Property(ht => ht.Id).ValueGeneratedOnAdd();
            builder.HasIndex(ht => ht.Title)
                .IsUnique();
            builder.Property(ht => ht.Title)
                .IsRequired();
            builder.Property(ht => ht.Description)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
            builder.HasQueryFilter(ht => ht.IsDelete == false);
            #endregion

            #region Relation Configuration
            builder.HasOne(ht => ht.Help).WithMany(h => h.HelpTopics)
                    .HasForeignKey(ht => ht.HelpId)
                    .OnDelete(DeleteBehavior.Cascade); 
            #endregion
        }
    }
}
