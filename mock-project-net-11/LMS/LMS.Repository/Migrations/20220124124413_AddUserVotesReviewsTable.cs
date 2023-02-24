using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddUserVotesReviewsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 24, 19, 44, 11, 30, DateTimeKind.Local).AddTicks(2878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 22, 23, 16, 35, 871, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Courses",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "OriginalPrice",
                table: "Courses",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "UserVotesReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ReviewId = table.Column<int>(nullable: false),
                    IsHelpful = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVotesReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVotesReviews_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserVotesReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c267bb18-7cfb-4ffa-8ba3-34f630f8efdd", "AQAAAAEAACcQAAAAECNETCtN2zhNRyZAfVO02VbuoM4CfWicGKLEddpBlRsjfywYLDOuFeuk06LfbxeOmQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "84b185d4-8957-4ddc-a46d-289d5b3f12b4", "AQAAAAEAACcQAAAAEC/b/XUqWNYzJBGhZbOYsGoHYMQsKJ2lCjHyBwo1zbWCzFCUK/+caoRncRHuhH4sWQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c85b55ed-bbc6-4355-9384-3b27b6fde3aa", "AQAAAAEAACcQAAAAEKXZR6dca/zcYsiYSeFEvVB0ew6XjmrCvULKDhbNNgwQw/YpvtSd7qwDm9l7t8pAbQ==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(199), new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(216) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(259), new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(263), new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(265) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(266), new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(268) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(270), new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(271) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 44, DateTimeKind.Local).AddTicks(4623), new DateTime(2022, 1, 24, 19, 44, 11, 44, DateTimeKind.Local).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 10, 999, DateTimeKind.Local).AddTicks(9113), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(5889) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6861), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6883) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6903), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6905) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6908), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6912), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6913) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6915), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6916) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6918), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6919) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6921), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6922) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6924), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6925) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6927), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6928) });

            migrationBuilder.CreateIndex(
                name: "IX_UserVotesReviews_ReviewId",
                table: "UserVotesReviews",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVotesReviews_UserId_ReviewId",
                table: "UserVotesReviews",
                columns: new[] { "UserId", "ReviewId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVotesReviews");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 22, 23, 16, 35, 871, DateTimeKind.Local).AddTicks(3511),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 1, 24, 19, 44, 11, 30, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "OriginalPrice",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "473fce15-8138-494b-a058-62387c7cb2aa", "AQAAAAEAACcQAAAAEK6EUyBaHGDUhq3pDIaEM+mTKzzOsSjZ1C+q91ztsVI5JdWLrQVgA59FDrDxRuxNlQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a57873c0-9bb6-4dbd-b7eb-ed0a859c0b5f", "AQAAAAEAACcQAAAAENQ4ezbzxH8r75a0vWoVDURa351M1dg3qR7qRE0TBdGMaH6FjODNhoMER0GIt+lD0w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4cedebca-3924-425a-a734-471000f074cd", "AQAAAAEAACcQAAAAEG7GcBqupXLEiXGSvDVEf9nyzns+rrTBusyZHX1ShdW0ubyMmhhas+TjB/hATznapw==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(369), new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(428), new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(432), new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(435), new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(438), new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(439) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 880, DateTimeKind.Local).AddTicks(9415), new DateTime(2022, 1, 22, 23, 16, 35, 880, DateTimeKind.Local).AddTicks(9443) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 848, DateTimeKind.Local).AddTicks(7291), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(1828) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2492), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2530), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2531) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2533), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2537), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2538) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2540), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2541) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2543), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2545) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2546), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2548) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2550), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2551) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2553), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2554) });
        }
    }
}
