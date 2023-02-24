using System;
using System.Collections.Generic;
using System.Text;
using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class PrivacySettingConfiguration : IEntityTypeConfiguration<PrivacySetting>
    {
        public void Configure(EntityTypeBuilder<PrivacySetting> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.ShowYourProfileOnSearchEngines)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.ShowCoursesYouAreTakingOnYourProfilePage)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(x => x.User)
                .WithOne(x => x.PrivacySetting)
                .HasForeignKey<PrivacySetting>(x => x.UserId);
        }
    }
}
