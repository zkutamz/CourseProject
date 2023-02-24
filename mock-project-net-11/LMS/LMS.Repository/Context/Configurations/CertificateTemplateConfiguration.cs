using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class CertificateTemplateConfiguration : IEntityTypeConfiguration<CertificateTemplate>
    {
        public void Configure(EntityTypeBuilder<CertificateTemplate> builder)
        {
            builder.HasKey(x => new { x.CertificateId, x.TemplateId });

            builder.HasOne(x => x.Template)
                .WithMany(x => x.CertificateTemplates)
                .HasForeignKey(x => x.TemplateId)
                .IsRequired();

            builder.HasOne(x => x.Certificate)
                .WithMany(x => x.CertificateTemplates)
                .HasForeignKey(x => x.CertificateId)
                .IsRequired();
        }
    }
}
