using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class HelpConfiguration : IEntityTypeConfiguration<Help>
    {
        public void Configure(EntityTypeBuilder<Help> builder)
        {
            builder.Property(h => h.Id)
                .ValueGeneratedOnAdd();
            builder.HasIndex(h => h.UserContent)
                .IsUnique();
            builder.Property(h => h.UserContent)
                .HasColumnType("nvarchar(30)")
                .IsRequired();
            builder.HasQueryFilter(h => h.IsDelete == false);
        }
    }
}
