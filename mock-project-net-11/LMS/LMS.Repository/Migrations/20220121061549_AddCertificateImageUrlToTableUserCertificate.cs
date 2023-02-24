using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddCertificateImageUrlToTableUserCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageCertificateUrl",
                table: "UserCertificates",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64750cce-29fc-4269-934e-a2e70dbce78a", "AQAAAAEAACcQAAAAEAiRrrrS6kmV+IOiy3hp9NaK1/IPAcHiCoHpYh7/FbFsSu2YGu1s5cMfH//LVqbmOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f094f52-8fa2-4001-a9f8-35ede3cf12da", "AQAAAAEAACcQAAAAEJUNzeAc2Vnx0yzIOTEcSDjMVeavWYlHbBq9NI9k54bF/EqebCXWnOsyS9fzQYtiBQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "36331336-c5fe-4213-8dc0-7f87dbc96e21", "AQAAAAEAACcQAAAAEHfTmx9JtCozQd1AhiXZLglXkiE2yFHjpJrBw/eEeheqvZkBu4isSZih7S/YKDN3aw==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 952, DateTimeKind.Local).AddTicks(9440), new DateTime(2022, 1, 21, 13, 15, 47, 952, DateTimeKind.Local).AddTicks(9471) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 952, DateTimeKind.Local).AddTicks(9570), new DateTime(2022, 1, 21, 13, 15, 47, 952, DateTimeKind.Local).AddTicks(9574) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 952, DateTimeKind.Local).AddTicks(9582), new DateTime(2022, 1, 21, 13, 15, 47, 952, DateTimeKind.Local).AddTicks(9586) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 952, DateTimeKind.Local).AddTicks(9591), new DateTime(2022, 1, 21, 13, 15, 47, 952, DateTimeKind.Local).AddTicks(9595) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 952, DateTimeKind.Local).AddTicks(9599), new DateTime(2022, 1, 21, 13, 15, 47, 952, DateTimeKind.Local).AddTicks(9603) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 948, DateTimeKind.Local).AddTicks(9609), new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(513) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1793), new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1831) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1862), new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1866) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1872), new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1882), new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1885) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1891), new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1895) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1900), new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1904) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1909), new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1913) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1918), new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1922) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1927), new DateTime(2022, 1, 21, 13, 15, 47, 950, DateTimeKind.Local).AddTicks(1930) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageCertificateUrl",
                table: "UserCertificates");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5bd6a6a1-6a94-4265-b27e-529f71f0df8f", "AQAAAAEAACcQAAAAEHneWs6HQwOpusOyfjTReLDLN0w79uzAZWMBH5oOXY6NyZAzxuf4oJwoU6MLL5knjQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d8232a2-c2ad-41a0-ad1e-f27bfa903fbc", "AQAAAAEAACcQAAAAEGwqdF5We8CBEU8qL3xtYHA/Jq7d4N+2+YfZrFOvIMKhNQh9B2+xOogssLqHimabzw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b0223cf-859c-408c-8d5a-d22791dee8f6", "AQAAAAEAACcQAAAAEIXkBUjtjFJul1UgFVa8vVXaWLLwKswBapI5wOKGIahSjbW+3UvFVhBQYsOoXAAc2g==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3353), new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3372) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3411), new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3413) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3415), new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3417) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3418), new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3422), new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3423) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 599, DateTimeKind.Local).AddTicks(4794), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(633), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(649) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(662), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(663) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(666), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(668) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(670), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(671) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(673), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(677), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(678) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(680), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(682) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(684), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(685) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(687), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(689) });
        }
    }
}
