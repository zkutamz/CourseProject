using LMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repository.Context.Configurations
{
    /// <summary>
    /// This class store configurations of Lesson domain class for fluent API
    /// </summary>
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            #region Property configurations

            builder.Property(a => a.FirstName).HasColumnType("nvarchar(255)");
            builder.Property(a => a.LastName).HasColumnType("nvarchar(255)");
            builder.Property(a => a.Intro).HasColumnType("nvarchar(4000)").HasDefaultValue(string.Empty);
            builder.Property(a => a.Headline).HasColumnType("nvarchar(255)").HasDefaultValue(string.Empty);
            builder.Property(a => a.ProfileLink).HasColumnType("varchar(255)").HasDefaultValue(string.Empty);
            builder.Property(a => a.FacebookLink).HasColumnType("varchar(255)").HasDefaultValue(string.Empty);
            builder.Property(a => a.TwitterLink).HasColumnType("varchar(255)").HasDefaultValue(string.Empty);
            builder.Property(a => a.LinkedInLink).HasColumnType("varchar(255)").HasDefaultValue(string.Empty);
            builder.Property(a => a.YoutubeLink).HasColumnType("varchar(255)").HasDefaultValue(string.Empty);
            builder.Property(a => a.IsDelete).HasDefaultValue(false);
            builder.Property(a => a.ProfileViewCount).IsRequired();
            builder.Property(a => a.UpVote).IsRequired();
            builder.Property(a => a.DownVote).IsRequired();
            
            builder.HasQueryFilter(a => a.IsDelete == false);

            #endregion

            #region Relationship configurations


            #endregion
        }
    }
}
