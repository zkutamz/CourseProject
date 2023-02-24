using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// This class store configurations of EnrollCourse domain class for fluent API
    /// </summary>
    public class EnrollCourseConfiguration : IEntityTypeConfiguration<EnrollCourse>
    {
        public void Configure(EntityTypeBuilder<EnrollCourse> builder)
        {
            #region Property configurations
            builder.Property(n => n.CertificationURL).HasColumnType("nvarchar(255)");
            builder.Property(n => n.Note).HasColumnType("nvarchar(2000)");
            builder.Property(n => n.IsCertificate).HasDefaultValue(false);
            builder.Property(n => n.EnrollDate).IsRequired();
            builder.HasQueryFilter(ec => ec.IsDelete == false);
            #endregion
            #region Relationship configurations
            builder.HasOne<Course>(ec => ec.Course)
                    .WithMany(c => c.EnrollCourses)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasForeignKey(ec => ec.CourseId)
                    .IsRequired();
            builder.HasOne<AppUser>(ec => ec.AppUser)
                   .WithMany(u => u.EnrollCourses)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(n => n.StudentId)
                   .IsRequired();
            #endregion
        }
    }
}
