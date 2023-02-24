using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class FixConfigAndAddIsDeteleColumnToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 26, 13, 56, 1, 469, DateTimeKind.Local).AddTicks(1685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 25, 15, 9, 42, 733, DateTimeKind.Local).AddTicks(5812));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "de49c251-b4a5-4c0f-9a12-aca02f9cd14e", "AQAAAAEAACcQAAAAEGIxtJpnowkzTzlg4FECNY7BhnXnhxqQC6L1uMA8AemyUwkOnDju0S3Ke8tUHaxCKg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "de2c23e1-0b4f-44fa-b35f-55313439b59c", "AQAAAAEAACcQAAAAEEpt/IzjCQo9OaptP1nBqUmmEAgP+44XuPrPCMYeB8aeJfc+MeZB2JWdQOZ5NXYfTw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "24661eda-36e9-479c-8222-6a695eda5cee", "AQAAAAEAACcQAAAAEESW+q/1EX/60j1hKBsNYEVRbDWKx29yyO3f76Z3BlCTWd0TFHDPpeA1COuyfPk2UA==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 448, DateTimeKind.Local).AddTicks(7794), new DateTime(2022, 1, 26, 13, 56, 1, 448, DateTimeKind.Local).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 448, DateTimeKind.Local).AddTicks(7828), new DateTime(2022, 1, 26, 13, 56, 1, 448, DateTimeKind.Local).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 448, DateTimeKind.Local).AddTicks(7832), new DateTime(2022, 1, 26, 13, 56, 1, 448, DateTimeKind.Local).AddTicks(7834) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 448, DateTimeKind.Local).AddTicks(7836), new DateTime(2022, 1, 26, 13, 56, 1, 448, DateTimeKind.Local).AddTicks(7838) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 448, DateTimeKind.Local).AddTicks(7841), new DateTime(2022, 1, 26, 13, 56, 1, 448, DateTimeKind.Local).AddTicks(7843) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 478, DateTimeKind.Local).AddTicks(8394), new DateTime(2022, 1, 26, 13, 56, 1, 478, DateTimeKind.Local).AddTicks(8442) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(1143), new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5829), new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5834) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5836), new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5839), new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5842), new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5844) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5846), new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5849), new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5850) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5852), new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5853) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5855), new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5856) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5858), new DateTime(2022, 1, 26, 13, 56, 1, 447, DateTimeKind.Local).AddTicks(5859) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 25, 15, 9, 42, 733, DateTimeKind.Local).AddTicks(5812),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 1, 26, 13, 56, 1, 469, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56465e21-5205-45eb-9c98-bebea80a4b1a", "AQAAAAEAACcQAAAAEDEuPq/OTGdpzBFZPXcYrtY/ASvJ0iv0PTaQ3Z/zIzoFNKesr0S9Xy/veE4+xLCEXA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "46cbd383-9160-4ef9-9160-73bf9513042f", "AQAAAAEAACcQAAAAEEZLh5JoPQdQelnD9dNpfLR3htvjTmHQRA0zxh7WADGRD/qf2Q41EUqJgwZ9D8aVTg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e72b89ee-0a39-448d-862f-71e2b1756b01", "AQAAAAEAACcQAAAAEMB5Pft9KwqU7fZQsZihDiMZkMyn+dbidezz1K4ydOXKhITUgwcblVrJcdFXM8NM+A==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(4997), new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5056), new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5061) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5066), new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5074), new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5078) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5083), new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5086) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 756, DateTimeKind.Local).AddTicks(9728), new DateTime(2022, 1, 25, 15, 9, 42, 756, DateTimeKind.Local).AddTicks(9825) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(121), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5924), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5928) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5931), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5932) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5936), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5938) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5941), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5943) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5945), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5949), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5951) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5953), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5954) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5956), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5958) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5960), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5961) });
        }
    }
}
