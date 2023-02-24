using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class UpdateQuizSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "QuizSections");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "QuizSections");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "QuizSections");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "QuizSections");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "QuizSections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "QuizSections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "QuizSections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "QuizSections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ec476ca8-84dc-4688-a523-984569029797", "AQAAAAEAACcQAAAAENT5x4bilyzO7XFnFe0ha1+Nf4ZHKj8KlMBU2uKVn/W5ZDoKD2DPzojM8PX9rX7izw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b8dbc53-ce9c-4ba9-a687-31cf2ec77e16", "AQAAAAEAACcQAAAAECsRCMIO8aT87/dA1SnDK5ffZ7l47f9Qza+ol6eEfgmroBM2X1+VrqvpL3r023dpiQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3a00c798-6d6d-475b-8a93-f661452f298b", "AQAAAAEAACcQAAAAEMl2VkxuoziqSdmX+YlFD+MxHaOBuJhwZS5M4MkOjwgs4ZKGz/wyxNrMRz7X9nzJag==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4090), new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4107) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4151), new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4155), new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4159), new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4162), new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 231, DateTimeKind.Local).AddTicks(5745), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1365), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1381) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1396), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1398) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1400), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1401) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1403), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1407), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1409) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1411), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1412) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1414), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1416) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1418), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1422), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1423) });
        }
    }
}
