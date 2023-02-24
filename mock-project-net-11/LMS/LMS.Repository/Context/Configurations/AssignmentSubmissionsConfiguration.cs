using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// Configuration for table AssignmentSubmissions
    /// </summary>
    public class AssignmentSubmissionsConfiguration : IEntityTypeConfiguration<AssignmentSubmissions>
    {
        public void Configure(EntityTypeBuilder<AssignmentSubmissions> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.User)
                .WithMany(x => x.AssignmentSubmissions)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Assignment)
                .WithMany(x => x.AssignmentSubmissions)
                .HasForeignKey(x => x.AssignmentId)
                ;

        }
    }
}
