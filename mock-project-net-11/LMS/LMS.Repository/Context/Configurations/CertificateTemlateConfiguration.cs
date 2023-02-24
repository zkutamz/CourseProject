using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Context.Configurations
{
    public class CertificateTemlateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new Template()
                {
                    Id = 1,
                    TemplateName = "Template 1",
                    TemplateUrl = @"\Certificates\CertificateTemplates\templates\ec022e5c-3c40-404b-90d8-9837f348ac5f.html",
                    CreatedAt = DateTime.Now,
                    IsDelete = false,
                    UpdatedAt = DateTime.Now,
                });
        }
    }
}
