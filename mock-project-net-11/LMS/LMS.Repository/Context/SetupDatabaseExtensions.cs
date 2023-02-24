using System;
using LMS.Repository.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Repository.Context
{
    public static class SetupDatabaseExtensions
    {
        public static void ConfigureApplicationContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LMSApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LMSDB"));
            });
        }

        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "7C1C661E-39EF-4BBE-BCFB-F0332769F9B2"
                },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "Student",
                    NormalizedName = "STUDENT",
                    ConcurrencyStamp = "F9198767-CFDF-48A4-AFF1-229DFAD490DE"
                },
                new IdentityRole<int>
                {
                    Id = 3,
                    Name = "Instructor",
                    NormalizedName = "INSTRUCTOR",
                    ConcurrencyStamp = "10B8F556-CD23-450E-A730-04732C046E9F"
                }
            );

            var hasher = new PasswordHasher<AppUser>();

            builder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "admin@mail.com",
                    NormalizedUserName = "ADMIN@MAIL.COM",
                    Email = "admin@mail.com",
                    NormalizedEmail = "ADMIN@MAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abc@123"),
                    SecurityStamp = string.Empty,
                    FirstName = "Ad",
                    LastName = "Min",
                    BirthDate = new DateTime(1995, 08, 08),
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "student@mail.com",
                    NormalizedUserName = "STUDENT@MAIL.COM",
                    Email = "student@mail.com",
                    NormalizedEmail = "STUDENT@MAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abc@123"),
                    SecurityStamp = string.Empty,
                    FirstName = "Stu",
                    LastName = "Dent",
                    BirthDate = new DateTime(2000, 01, 01),
                },
                new AppUser
                {
                    Id = 3,
                    UserName = "instructor@mail.com",
                    NormalizedUserName = "INSTRUCTOR@MAIL.COM",
                    Email = "instructor@mail.com",
                    NormalizedEmail = "INSTRUCTOR@MAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abc@123"),
                    SecurityStamp = string.Empty,
                    FirstName = "In",
                    LastName = "Structor",
                    BirthDate = new DateTime(1990, 01, 01),
                });

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>
                {
                    UserId = 3,
                    RoleId = 3
                });

            builder.Entity<NotificationSetting>().HasData(
                new NotificationSetting
                {
                    UserId = 1
                },
                new NotificationSetting
                {
                    UserId = 2
                },
                new NotificationSetting
                {
                    UserId = 3
                });

            builder.Entity<PrivacySetting>().HasData(
                new PrivacySetting
                {
                    UserId = 1
                },
                new PrivacySetting
                {
                    UserId = 2
                },
                new PrivacySetting
                {
                    UserId = 3
                }
            );

            builder.Entity<WithdrawalMethod>().HasData(
                new WithdrawalMethod
                {
                    Id = 1,
                    Name = "Paypal"
                },
                new WithdrawalMethod
                {
                    Id = 2,
                    Name = "Payoneer"
                },
                new WithdrawalMethod
                {
                    Id = 3,
                    Name = "Swift"
                }
            );

            builder.Entity<BillingAddress>().HasData(
                new BillingAddress
                {
                    UserId = 1,
                    WithdrawalMethodId = 1
                },
                new BillingAddress
                {
                    UserId = 2,
                    WithdrawalMethodId = 1
                },
                new BillingAddress
                {
                    UserId = 3,
                    WithdrawalMethodId = 1
                }
            );
        }
    }
}
