using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    ProfileImageUrl = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true),
                    Headline = table.Column<string>(nullable: true),
                    ProfileLink = table.Column<string>(nullable: true),
                    FacebookLink = table.Column<string>(nullable: true),
                    TwitterLink = table.Column<string>(nullable: true),
                    LinkedInLink = table.Column<string>(nullable: true),
                    YoutubeLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificateCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CertificateCatgoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    IsBlock = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Helps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    UserContent = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawalMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawalMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    SreenShot = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    LearningDate = table.Column<DateTime>(nullable: false),
                    Period = table.Column<float>(nullable: false, defaultValue: 0f),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningPeriods_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Details = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(maxLength: 100, nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    Header = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationSettings",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Subscriptions = table.Column<bool>(nullable: false, defaultValue: true),
                    RecommendedCourses = table.Column<bool>(nullable: false, defaultValue: false),
                    ActivityOnMyComment = table.Column<bool>(nullable: false, defaultValue: false),
                    RepliesToMyComments = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSettings", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_NotificationSettings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivacySettings",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ShowYourProfileOnSearchEngines = table.Column<bool>(nullable: false, defaultValue: false),
                    ShowCoursesYouAreTakingOnYourProfilePage = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivacySettings", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_PrivacySettings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubcribers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    SubcriberId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubcribers", x => new { x.SubcriberId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserSubcribers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => new { x.CategoryId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Specializations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specializations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CertificateName = table.Column<string>(nullable: true),
                    CertificateCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_CertificateCategories_CertificateCategoryId",
                        column: x => x.CertificateCategoryId,
                        principalTable: "CertificateCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatUser",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ChatId = table.Column<int>(nullable: false),
                    IsMute = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUser", x => new { x.ChatId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ChatUser_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false, defaultValue: false),
                    ChatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Question = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HelpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQs_Helps_HelpId",
                        column: x => x.HelpId,
                        principalTable: "Helps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HelpTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    IconURL = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    HelpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpTopics_Helps_HelpId",
                        column: x => x.HelpId,
                        principalTable: "Helps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderTotal = table.Column<decimal>(type: "money", nullable: false),
                    PaymentStatus = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    PaymentMethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_SessionId",
                        column: x => x.SessionId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingAddresses",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    AcademyName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PostalCode = table.Column<int>(nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    EmailPaypal = table.Column<string>(type: "varchar(255)", nullable: true),
                    WithdrawalMethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddresses", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_BillingAddresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillingAddresses_WithdrawalMethods_WithdrawalMethodId",
                        column: x => x.WithdrawalMethodId,
                        principalTable: "WithdrawalMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(220)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    OriginalPrice = table.Column<decimal>(nullable: false),
                    VideoUrl = table.Column<string>(nullable: true),
                    EmbeddedCode = table.Column<string>(nullable: true),
                    Announcement = table.Column<string>(nullable: true),
                    PublishedDate = table.Column<DateTime>(nullable: true),
                    Requirement = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    Feature = table.Column<bool>(nullable: false),
                    RequiredLogIn = table.Column<bool>(nullable: false),
                    RequireEnroll = table.Column<bool>(nullable: false),
                    WhatLearn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    TotalDuration = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    CourseStatus = table.Column<int>(nullable: false, defaultValue: 1),
                    AudioLanguage = table.Column<string>(nullable: false),
                    CloseCaption = table.Column<string>(nullable: false),
                    IntroOverviewUrl = table.Column<string>(nullable: true),
                    ThumbNailUrl = table.Column<string>(nullable: true),
                    InstructorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CertificateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCertificates",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CertificateId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCertificates", x => new { x.CertificateId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserCertificates_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCertificates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HelpArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HelpTopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpArticles_HelpTopics_HelpTopicId",
                        column: x => x.HelpTopicId,
                        principalTable: "HelpTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IsModified = table.Column<bool>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ParentCommentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseComment_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseComment_CourseComment_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "CourseComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnrollCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CompletedPercent = table.Column<decimal>(nullable: false),
                    CertificationURL = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CertificationDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    Score = table.Column<int>(nullable: false),
                    IsCertificate = table.Column<bool>(nullable: false, defaultValue: false),
                    EnrollDate = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EnrollCourses_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CourseId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoriteCourses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    OrderHeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    TotalTime = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitors_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    HelpfulnessRating = table.Column<int>(nullable: false, defaultValue: 0),
                    EnrollCourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_EnrollCourses_EnrollCourseId",
                        column: x => x.EnrollCourseId,
                        principalTable: "EnrollCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    TotalTime = table.Column<int>(nullable: false),
                    TotalNumber = table.Column<int>(nullable: false),
                    MinimumPassNumber = table.Column<int>(nullable: false),
                    UploadAttachmentLimit = table.Column<int>(nullable: false),
                    AssignmentUrl = table.Column<string>(nullable: true),
                    MaximumAttachmentSizeLimit = table.Column<int>(nullable: true),
                    SectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true),
                    EmbeddedCode = table.Column<string>(nullable: true),
                    AttachmentUrl = table.Column<string>(nullable: true),
                    TotalTime = table.Column<int>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    Title = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TotalTime = table.Column<int>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false, defaultValue: false),
                    IsExposedQuestion = table.Column<bool>(nullable: false),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionCompletions",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    CompleteDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionCompletions", x => new { x.UserId, x.SectionId });
                    table.ForeignKey(
                        name: "FK_SectionCompletions_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SectionCompletions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssignmentSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    SubmitDate = table.Column<DateTime>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    PercentCompleted = table.Column<float>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    AssignmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentSubmissions_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignmentSubmissions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonCompletion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CompletedDate = table.Column<DateTime>(nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonCompletion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonCompletion_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonCompletion_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    EnrollCourseId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_EnrollCourses_EnrollCourseId",
                        column: x => x.EnrollCourseId,
                        principalTable: "EnrollCourses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notes_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    Title = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ImgURL = table.Column<string>(nullable: true),
                    AudioURL = table.Column<string>(nullable: true),
                    VideoURL = table.Column<string>(nullable: true),
                    QuizQuestionType = table.Column<int>(nullable: false),
                    OptionA = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    OptionB = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    OptionC = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    OptionD = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ExplanationImageURL = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false, defaultValue: false),
                    QuizId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    SubmitDate = table.Column<DateTime>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CorectAnswers = table.Column<int>(nullable: false),
                    WrongAnswers = table.Column<int>(nullable: false),
                    TotalQuestion = table.Column<int>(nullable: false),
                    IsPassed = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    QuizId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizSubmissions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizSubmissions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizzCertificates",
                columns: table => new
                {
                    CertificateId = table.Column<int>(nullable: false),
                    QuizzId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizzCertificates", x => new { x.CertificateId, x.QuizzId });
                    table.ForeignKey(
                        name: "FK_QuizzCertificates_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizzCertificates_Quizzes_QuizzId",
                        column: x => x.QuizzId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    QuizQuestionId = table.Column<int>(nullable: false),
                    QuizSubmissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answers_QuizSubmissions_QuizSubmissionId",
                        column: x => x.QuizSubmissionId,
                        principalTable: "QuizSubmissions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 3, "10B8F556-CD23-450E-A730-04732C046E9F", "Instructor", "Instructor" },
                    { 1, "7C1C661E-39EF-4BBE-BCFB-F0332769F9B2", "Admin", "ADMIN" },
                    { 2, "F9198767-CFDF-48A4-AFF1-229DFAD490DE", "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "Headline", "Intro", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "ProfileLink", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "YoutubeLink" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1995, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "39e17849-d475-4ac6-a2aa-525d79572e0a", "admin@mail.com", true, null, "Ad", null, null, "Min", null, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEB9DOTZzuw3XJtCtrlfLbdUVXbMzxyFmTyV0nzDNNPZSqIo83xANImLUerlhGBHi0A==", null, false, null, null, "", null, false, "admin@mail.com", null },
                    { 3, 0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01ccd3fe-d1e6-4d50-b6a4-2889566461db", "instructor@mail.com", true, null, "In", null, null, "Structor", null, false, null, "INSTRUCTOR@MAIL.COM", "INSTRUCTOR@MAIL.COM", "AQAAAAEAACcQAAAAEBuoYaVCLrqE8YdwSsXh4VMrd5bDZfqZLSJT8Tdev5Yob/yFIBY3eilLB5snm0w2Hg==", null, false, null, null, "", null, false, "instructor@mail.com", null },
                    { 2, 0, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "58100eb9-98a8-4bbe-ba81-315a5f250af3", "student@mail.com", true, null, "Stu", null, null, "Dent", null, false, null, "STUDENT@MAIL.COM", "STUDENT@MAIL.COM", "AQAAAAEAACcQAAAAEEOyWs/h4uavKyWp+LLn1pjhNPhNtIJ0bGdenf9mGTA8EJJkckZWQcL2u8UwqFcjeA==", null, false, null, null, "", null, false, "student@mail.com", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDelete", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Game Design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Language Learning", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Web Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CertificateCategories",
                columns: new[] { "Id", "CertificateCatgoryName", "CreatedAt", "IsDelete", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Development", new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4519), false, new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4541) },
                    { 2, "Finance & Accounting", new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4579), false, new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4581) },
                    { 4, "Maketing", new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4586), false, new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4588) },
                    { 5, "Teaching & Academics", new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4590), false, new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4591) },
                    { 3, "Design", new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4583), false, new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4585) }
                });

            migrationBuilder.InsertData(
                table: "WithdrawalMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Paypal" },
                    { 2, "Payoneer" },
                    { 3, "Swift" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "BillingAddresses",
                columns: new[] { "UserId", "AcademyName", "AddressLine1", "AddressLine2", "City", "Country", "EmailPaypal", "FirstName", "LastName", "PhoneNumber", "PostalCode", "Province", "WithdrawalMethodId" },
                values: new object[,]
                {
                    { 3, null, null, null, null, null, null, null, null, null, null, null, 1 },
                    { 2, null, null, null, null, null, null, null, null, null, null, null, 1 },
                    { 1, null, null, null, null, null, null, null, null, null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "CertificateCategoryId", "CertificateName", "CreatedAt", "IsDelete", "UpdatedAt" },
                values: new object[,]
                {
                    { 10, 5, "Humanities2", new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1533), false, new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1534) },
                    { 9, 5, "Humanities", new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1530), false, new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1531) },
                    { 8, 5, "IELTS", new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1525), false, new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1527) },
                    { 7, 4, "Bussiness Stragy", new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1520), false, new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1522) },
                    { 6, 4, "SEO", new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1516), false, new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1518) },
                    { 5, 3, "Adobe Photoshop", new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1513), false, new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1515) },
                    { 3, 2, "Finance", new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1506), false, new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1508) },
                    { 2, 2, "Accounting", new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1473), false, new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1493) },
                    { 1, 1, "Wordpress", new DateTime(2022, 1, 20, 13, 9, 11, 455, DateTimeKind.Local).AddTicks(5991), false, new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1042) },
                    { 4, 3, "2D Animation", new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1510), false, new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1512) }
                });

            migrationBuilder.InsertData(
                table: "NotificationSettings",
                column: "UserId",
                values: new object[]
                {
                    3,
                    2,
                    1
                });

            migrationBuilder.InsertData(
                table: "PrivacySettings",
                column: "UserId",
                values: new object[]
                {
                    3,
                    2,
                    1
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Announcement", "AudioLanguage", "CategoryId", "CertificateId", "CloseCaption", "CourseStatus", "CreatedAt", "Description", "EmbeddedCode", "Feature", "InstructorId", "IntroOverviewUrl", "IsDelete", "Level", "OriginalPrice", "Price", "PublishedDate", "RequireEnroll", "RequiredLogIn", "Requirement", "ShortDescription", "ThumbNailUrl", "Title", "TotalDuration", "UpdatedAt", "VideoUrl", "ViewCount", "WhatLearn" },
                values: new object[] { 1, null, "English", 2, 1, "English", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome to The Blender Encyclopedia, the most comprehensive training course available for Blender, a completely free and open source 3D production suite.Our aim with the course was to make an expanded version of the Blender Manual, that you can follow along or reference at any time in your 3D journey.Further than the tools alone, we've made sure this course contains not just the how, but the why. Throughout the course, we've crafted example demos, as well as step by step projects,that will take what you've learned and form it into a practical example. You can get all the Blender files used in the lectures, complete with models,textures and other resources.This includes starting files so you can join in!You can use these resource files in your own projects as well.Just open them up to see their license details, if any.We have created this course specifically for Udemy, and you will have unlimited support from us in the Q & A section of each lecture.See you in the course, and happy blending!", null, false, 3, null, false, 1, 49m, 49m, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Blender 2.8 or Blender 2.9", "Welcome to The Blender Encyclopedia", "blender.jpg", "The Blender 2.8 Encyclopedia Version 1", 165600, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Nothing" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Announcement", "AudioLanguage", "CategoryId", "CertificateId", "CloseCaption", "CourseStatus", "CreatedAt", "Description", "EmbeddedCode", "Feature", "InstructorId", "IntroOverviewUrl", "IsDelete", "Level", "OriginalPrice", "Price", "PublishedDate", "RequireEnroll", "RequiredLogIn", "Requirement", "ShortDescription", "ThumbNailUrl", "Title", "TotalDuration", "UpdatedAt", "VideoUrl", "ViewCount", "WhatLearn" },
                values: new object[] { 2, null, "English", 2, 2, "English", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome to The Blender Encyclopedia, the most comprehensive training course available for Blender, a completely free and open source 3D production suite.Our aim with the course was to make an expanded version of the Blender Manual, that you can follow along or reference at any time in your 3D journey.Further than the tools alone, we've made sure this course contains not just the how, but the why. Throughout the course, we've crafted example demos, as well as step by step projects,that will take what you've learned and form it into a practical example. You can get all the Blender files used in the lectures, complete with models,textures and other resources.This includes starting files so you can join in!You can use these resource files in your own projects as well.Just open them up to see their license details, if any.We have created this course specifically for Udemy, and you will have unlimited support from us in the Q & A section of each lecture.See you in the course, and happy blending!", null, false, 3, null, false, 1, 49m, 49m, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Blender 2.8 or Blender 2.9", "Welcome to The Blender Encyclopedia", "blender.jpg", "The Blender 2.8 Encyclopedia V2", 165600, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Nothing" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuizQuestionId",
                table: "Answers",
                column: "QuizQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuizSubmissionId",
                table: "Answers",
                column: "QuizSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SectionId",
                table: "Assignments",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmissions_AssignmentId",
                table: "AssignmentSubmissions",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmissions_UserId",
                table: "AssignmentSubmissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddresses_WithdrawalMethodId",
                table: "BillingAddresses",
                column: "WithdrawalMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CertificateCategoryId",
                table: "Certificates",
                column: "CertificateCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUser_UserId",
                table: "ChatUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComment_CourseId",
                table: "CourseComment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComment_ParentCommentId",
                table: "CourseComment",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComment_UserId",
                table: "CourseComment",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CertificateId",
                table: "Courses",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Title",
                table: "Courses",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnrollCourses_CourseId",
                table: "EnrollCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollCourses_StudentId",
                table: "EnrollCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_HelpId",
                table: "FAQs",
                column: "HelpId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCourses_CourseId",
                table: "FavoriteCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCourses_UserId",
                table: "FavoriteCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpArticles_HelpTopicId",
                table: "HelpArticles",
                column: "HelpTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpTopics_HelpId",
                table: "HelpTopics",
                column: "HelpId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningPeriods_UserId",
                table: "LearningPeriods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonCompletion_LessonId",
                table: "LessonCompletion",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonCompletion_UserId",
                table: "LessonCompletion",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SectionId",
                table: "Lessons",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_EnrollCourseId",
                table: "Notes",
                column: "EnrollCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_LessonId",
                table: "Notes",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CourseId",
                table: "OrderDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_PaymentMethodId",
                table: "OrderHeaders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_SessionId",
                table: "OrderHeaders",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizId",
                table: "QuizQuestions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmissions_QuizId",
                table: "QuizSubmissions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmissions_UserId",
                table: "QuizSubmissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizzCertificates_CertificateId",
                table: "QuizzCertificates",
                column: "CertificateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizzCertificates_QuizzId",
                table: "QuizzCertificates",
                column: "QuizzId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_SectionId",
                table: "Quizzes",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_EnrollCourseId",
                table: "Reviews",
                column: "EnrollCourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionCompletions_SectionId",
                table: "SectionCompletions",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_UserId",
                table: "Specializations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCertificates_UserId",
                table: "UserCertificates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubcribers_UserId",
                table: "UserSubcribers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_CourseId",
                table: "Visitors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_UserId",
                table: "Visitors",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssignmentSubmissions");

            migrationBuilder.DropTable(
                name: "BillingAddresses");

            migrationBuilder.DropTable(
                name: "ChatUser");

            migrationBuilder.DropTable(
                name: "CourseComment");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "FavoriteCourses");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "HelpArticles");

            migrationBuilder.DropTable(
                name: "LearningPeriods");

            migrationBuilder.DropTable(
                name: "LessonCompletion");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationSettings");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "PrivacySettings");

            migrationBuilder.DropTable(
                name: "QuizzCertificates");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SectionCompletions");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "UserCertificates");

            migrationBuilder.DropTable(
                name: "UserSubcribers");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "QuizSubmissions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "WithdrawalMethods");

            migrationBuilder.DropTable(
                name: "HelpTopics");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "EnrollCourses");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Helps");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CertificateCategories");
        }
    }
}
