using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class SpecializationConfiguration : IEntityTypeConfiguration<Specializations>
    {
        public void Configure(EntityTypeBuilder<Specializations> builder)
        {
            #region  config FK and PK to table Specializations
            builder.Property(p=>p.Id).UseIdentityColumn(1,1);

            builder.HasKey(p=> new {p.CategoryId, p.UserId});

            builder.HasOne(p=>p.Category)
            .WithMany(p=>p.Specializations)
            .HasForeignKey(p=>p.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

              builder.HasOne(p=>p.User)
            .WithMany(p=>p.Specializations)
            .HasForeignKey(p=>p.UserId)
            .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}