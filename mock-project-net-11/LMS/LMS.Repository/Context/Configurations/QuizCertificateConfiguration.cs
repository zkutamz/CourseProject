using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class QuizCertificateConfiguration : IEntityTypeConfiguration<QuizzCertificate>
    {
        public void Configure(EntityTypeBuilder<QuizzCertificate> builder)
        {
            builder.HasKey(x => new { x.CertificateId, x.QuizzId });

            builder.HasOne(x => x.Certificate)
                .WithOne(x => x.QuizCertificate)
                .HasForeignKey<QuizzCertificate>(x => x.CertificateId).IsRequired();
            builder.HasOne(x => x.Quiz)
                .WithOne(x => x.QuizCertificate)
                .HasForeignKey<QuizzCertificate>(x => x.QuizzId).IsRequired();
        }
    }
}
