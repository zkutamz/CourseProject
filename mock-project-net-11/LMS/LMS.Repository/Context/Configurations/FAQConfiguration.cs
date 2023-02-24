using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            builder.ToTable("FAQs");

            #region Property configurations
            
            builder.Property(r => r.Question)
                .HasColumnType("nvarchar(4000)")
                .IsRequired();
            builder.Property(r => r.Answer)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
            builder.HasQueryFilter(f => f.IsDelete == false);

            #endregion

            #region Relation configuration
            builder.HasOne(f => f.Help).WithMany(h => h.FAQs)
                    .HasForeignKey(f => f.HelpId)
                    .OnDelete(DeleteBehavior.Cascade); 
            #endregion
        }
    }
}
