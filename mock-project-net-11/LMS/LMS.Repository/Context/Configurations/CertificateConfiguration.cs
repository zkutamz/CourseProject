using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.CertificateCategory)
                 .WithMany(x => x.Certificate)
                 .HasForeignKey(x => x.CertificateCategoryId);
                 
            builder.HasOne(x => x.Course)
                .WithOne(x => x.Certificate)
                .HasForeignKey<Certificate>(x => x.CourseId);
           
            builder.HasData(
               new Certificate()
               {
                   Id = 1,
                   CertificateName = "Wordpress",
                   CertificateCategoryId = 1,
                   IsDelete = false,
                   CreatedAt = System.DateTime.Now,
                   UpdatedAt = System.DateTime.Now
               },
               new Certificate()
               {
                   Id = 2,
                   CertificateName = "Accounting",
                   CertificateCategoryId = 2,
                   IsDelete = false,
                   CreatedAt = System.DateTime.Now,
                   UpdatedAt = System.DateTime.Now

               },
               new Certificate()
               {
                   Id = 3,
                   CertificateName = "Finance",
                   CertificateCategoryId = 2,
                   IsDelete = false,
                   CreatedAt = System.DateTime.Now,
                   UpdatedAt = System.DateTime.Now

               },
               new Certificate()
               {
                   Id = 4,
                   CertificateName = "2D Animation",
                   CertificateCategoryId = 3,
                   IsDelete = false,
                   CreatedAt = System.DateTime.Now,
                   UpdatedAt = System.DateTime.Now
               },
               new Certificate()
               {
                   Id = 5,
                   CertificateName = "Adobe Photoshop",
                   CertificateCategoryId = 3,
                   IsDelete = false,
                   CreatedAt = System.DateTime.Now,
                   UpdatedAt = System.DateTime.Now
               },
               new Certificate()
               {
                   Id = 6,
                   CertificateName = "SEO",
                   CertificateCategoryId = 4,
                   IsDelete = false,
                   CreatedAt = System.DateTime.Now,
                   UpdatedAt = System.DateTime.Now
               },
               new Certificate()
               {
                   Id = 7,
                   CertificateName = "Bussiness Stragy",
                   CertificateCategoryId = 4,
                   IsDelete = false,
                   CreatedAt = System.DateTime.Now,
                   UpdatedAt = System.DateTime.Now
               },
               new Certificate()
               {
                   Id = 8,
                   CertificateName = "IELTS",
                   CertificateCategoryId = 5,
                   IsDelete = false,
                   CreatedAt = System.DateTime.Now,
                   UpdatedAt = System.DateTime.Now
               },
               new Certificate()
               {
                   Id = 9,
                   CertificateName = "Humanities",
                   CertificateCategoryId = 5,
                   IsDelete = false,
                   CreatedAt = System.DateTime.Now,
                   UpdatedAt = System.DateTime.Now
               },
               new Certificate()
               {
                   Id = 10,
                   CertificateName = "Humanities2",
                   CertificateCategoryId = 5,
                   IsDelete = false,
                   CreatedAt = System.DateTime.Now,
                   UpdatedAt = System.DateTime.Now
               });
        }
    }
}
