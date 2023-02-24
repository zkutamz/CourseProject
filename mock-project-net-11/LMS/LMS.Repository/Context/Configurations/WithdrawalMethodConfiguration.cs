using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class WithdrawalMethodConfiguration : IEntityTypeConfiguration<WithdrawalMethod>
    {
        public void Configure(EntityTypeBuilder<WithdrawalMethod> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("varchar(255)")
                .IsRequired();
        }
    }
}
