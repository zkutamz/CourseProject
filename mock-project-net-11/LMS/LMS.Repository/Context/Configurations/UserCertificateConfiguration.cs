using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Context.Configurations
{
    public class UserCertificateConfiguration : IEntityTypeConfiguration<UserCertificate>
    {
        public void Configure(EntityTypeBuilder<UserCertificate> builder)
        {
            builder.HasKey(x => new { x.CertificateId, x.UserId });
            builder.Property(x => x.IsDelete).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserCertificates)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Certificate)
                .WithMany(x => x.UserCertificates)
                .HasForeignKey(x => x.CertificateId);
        }
    }
}
