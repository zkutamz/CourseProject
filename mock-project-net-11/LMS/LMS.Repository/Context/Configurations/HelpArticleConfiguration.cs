using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class HelpArticleConfiguration : IEntityTypeConfiguration<HelpArticle>
    {
        public void Configure(EntityTypeBuilder<HelpArticle> builder)
        {
            #region Property Configuration
            builder.Property(ha => ha.Id)
                    .ValueGeneratedOnAdd();
            builder.Property(ha => ha.Title)
                .IsRequired();
            builder.Property(ha => ha.Content)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
            builder.HasQueryFilter(ha => ha.IsDelete == false);
            #endregion

            #region Relation Configuration
            builder.HasOne(ha => ha.HelpTopic).WithMany(ht => ht.HelpArticles)
                    .HasForeignKey(ha => ha.HelpTopicId)
                    .OnDelete(DeleteBehavior.Cascade); 
            #endregion
        }
    }
}
