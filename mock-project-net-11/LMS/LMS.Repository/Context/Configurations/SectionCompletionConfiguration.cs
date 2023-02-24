using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class SectionCompletionConfiguration : IEntityTypeConfiguration<SectionCompletion>
    {
        public void Configure(EntityTypeBuilder<SectionCompletion> builder)
        {
            #region
            builder.Property(p=>p.CompleteDate).HasDefaultValue(default);
            builder.HasKey(p=>new {p.UserId, p.SectionId});

            builder.HasOne(p=>p.User)
            .WithMany(p=>p.SectionCompletions)
            .HasForeignKey(p=>p.UserId)
            .OnDelete(DeleteBehavior.NoAction);

             builder.HasOne(p=>p.Section)
            .WithMany(p=>p.SectionCompletions)
            .HasForeignKey(p=>p.SectionId)
            .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}