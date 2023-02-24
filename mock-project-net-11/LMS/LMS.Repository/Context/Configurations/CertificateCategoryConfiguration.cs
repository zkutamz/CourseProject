using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    class CertificateCategoryConfiguration : IEntityTypeConfiguration<CertificateCategory>
    {
        public void Configure(EntityTypeBuilder<CertificateCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasData(
                new CertificateCategory()
                {
                    Id = 1,
                    CertificateCatgoryName = "Development",
                    IsDelete = false,
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now
                },
                new CertificateCategory()
                {
                    Id = 2,
                    CertificateCatgoryName = "Finance & Accounting",
                    IsDelete = false,
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now
                },
                new CertificateCategory()
                {
                    Id = 3,
                    CertificateCatgoryName = "Design",
                    IsDelete = false,
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now
                },
                new CertificateCategory()
                {
                    Id = 4,
                    CertificateCatgoryName = "Maketing",
                    IsDelete = false,
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now
                },
                new CertificateCategory()
                {
                    Id = 5,
                    CertificateCatgoryName = "Teaching & Academics",
                    IsDelete = false,
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now
                }
                );
        }
    }
}
