using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddConfigurationOfAppUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 26, 14, 27, 42, 565, DateTimeKind.Local).AddTicks(1645),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 26, 13, 56, 1, 469, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.AlterColumn<string>(
                name: "YoutubeLink",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TwitterLink",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfileLink",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkedInLink",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Intro",
                table: "AspNetUsers",
                type: "nvarchar(4000)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Headline",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacebookLink",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11c5781a-1a35-49f2-a985-f35365b0f1fa", "AQAAAAEAACcQAAAAEDVpqq7rftBXQZsWESZb2Qa9ntgENqxYC5kfR2ARW4KV0z7AC4YpPYlkGK32kQJvBA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6488e620-d6d4-40e3-846b-1550c7d4f946", "AQAAAAEAACcQAAAAEEhcgX2QP0H/KOZiaPE5A4oB7twzwaLkcV3weU+hBCt+HRTCdvqyNrF15hDb9D9A6A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "36f65f05-979b-40a3-a463-87e704acd859", "AQAAAAEAACcQAAAAEIfUm5N2h4gsc/MakK9g9Wxa6gCf5+Lw7RfG2s4HTqds/VV4y2G1OSS5Q2UupiY1qQ==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 542, DateTimeKind.Local).AddTicks(6226), new DateTime(2022, 1, 26, 14, 27, 42, 542, DateTimeKind.Local).AddTicks(6249) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 542, DateTimeKind.Local).AddTicks(6256), new DateTime(2022, 1, 26, 14, 27, 42, 542, DateTimeKind.Local).AddTicks(6259) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 542, DateTimeKind.Local).AddTicks(6261), new DateTime(2022, 1, 26, 14, 27, 42, 542, DateTimeKind.Local).AddTicks(6264) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 542, DateTimeKind.Local).AddTicks(6266), new DateTime(2022, 1, 26, 14, 27, 42, 542, DateTimeKind.Local).AddTicks(6269) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 542, DateTimeKind.Local).AddTicks(6271), new DateTime(2022, 1, 26, 14, 27, 42, 542, DateTimeKind.Local).AddTicks(6273) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 575, DateTimeKind.Local).AddTicks(8304), new DateTime(2022, 1, 26, 14, 27, 42, 575, DateTimeKind.Local).AddTicks(8340) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 540, DateTimeKind.Local).AddTicks(2721), new DateTime(2022, 1, 26, 14, 27, 42, 540, DateTimeKind.Local).AddTicks(9991) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(710), new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(722), new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(724) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(728), new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(731) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(734), new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(740) });
            
            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(743), new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(745) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(748), new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(751) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(754), new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(756) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(759), new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(762) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(764), new DateTime(2022, 1, 26, 14, 27, 42, 541, DateTimeKind.Local).AddTicks(767) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 26, 13, 56, 1, 469, DateTimeKind.Local).AddTicks(1685),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 1, 26, 14, 27, 42, 565, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.AlterColumn<string>(
                name: "YoutubeLink",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TwitterLink",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileLink",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LinkedInLink",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Intro",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Headline",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacebookLink",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldDefaultValue: "");

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
    }
}
