using System;
using System.Collections.Generic;
using System.Text;
using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    public class NotificationSettingConfiguration :IEntityTypeConfiguration<NotificationSetting>
    {
        public void Configure(EntityTypeBuilder<NotificationSetting> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Subscriptions)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.RecommendedCourses)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.ActivityOnMyComment)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.RepliesToMyComments)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(x => x.User)
                .WithOne(x => x.NotificationSetting)
                .HasForeignKey<NotificationSetting>(x => x.UserId);
        }
    }
}
