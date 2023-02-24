using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddImgURLInNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 2, 8, 51, 4, 870, DateTimeKind.Local).AddTicks(7969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 26, 0, 38, 31, 606, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "Notifications",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b5fa9d4-8349-4c42-8036-ef1c67c860ef", "AQAAAAEAACcQAAAAEOLPGiKxY32nnQWH7bx473vF6S3VDWDQOqPH6dnn1j/8xYH58YvvPKjbbE6UZJXDlg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "43e7517e-5cd3-4dbd-82da-6c385deff909", "AQAAAAEAACcQAAAAEBbXix0XL2Q3K12N3m4Rdr4lgDNuJb18zS2uuWbWiQ1zMwkaHSEGvLkSTdWuEKA3Qg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2677dd67-b6b8-49dd-9b12-f5fd351d9b9f", "AQAAAAEAACcQAAAAECLf6P2VMqGeTn4kG1YhuEbxF9DwGPUCcRjnAEvXu8WWdm5oFRtxMoL7GPaWXBXGFA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 786, DateTimeKind.Local).AddTicks(8314), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(2925) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3192), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3197) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3199), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3201) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3205), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3206) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3208), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3209) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3211), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3213) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3215), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3216) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3218), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3222), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3223) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3225), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3227) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3229), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3232), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3234) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3236), new DateTime(2022, 3, 2, 8, 51, 4, 787, DateTimeKind.Local).AddTicks(3237) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 845, DateTimeKind.Local).AddTicks(4085), new DateTime(2022, 3, 2, 8, 51, 4, 845, DateTimeKind.Local).AddTicks(4112) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 845, DateTimeKind.Local).AddTicks(4115), new DateTime(2022, 3, 2, 8, 51, 4, 845, DateTimeKind.Local).AddTicks(4117) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 845, DateTimeKind.Local).AddTicks(4120), new DateTime(2022, 3, 2, 8, 51, 4, 845, DateTimeKind.Local).AddTicks(4121) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 845, DateTimeKind.Local).AddTicks(4123), new DateTime(2022, 3, 2, 8, 51, 4, 845, DateTimeKind.Local).AddTicks(4125) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 845, DateTimeKind.Local).AddTicks(4127), new DateTime(2022, 3, 2, 8, 51, 4, 845, DateTimeKind.Local).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4384), new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4422) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4426), new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4427) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4429), new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4432), new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4433) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4435), new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4436) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4438), new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4440) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4442), new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4443) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4445), new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4446) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4448), new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4449) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4451), new DateTime(2022, 3, 2, 8, 51, 4, 844, DateTimeKind.Local).AddTicks(4453) });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 8, 51, 4, 885, DateTimeKind.Local).AddTicks(1060), new DateTime(2022, 3, 2, 8, 51, 4, 885, DateTimeKind.Local).AddTicks(1109) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "Notifications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 26, 0, 38, 31, 606, DateTimeKind.Local).AddTicks(7485),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 3, 2, 8, 51, 4, 870, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ef7df68b-b85e-4e9d-b570-7935c85eda02", "AQAAAAEAACcQAAAAEOUyKLIQZo76r/fZQLrc0lldUMsPHfsWhKE/Xbz7vQ2Xm+VQY4roHc5nYzfRAXy6ww==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "40f7c9f1-1fd5-42a3-b2dc-f2cbe94d09ee", "AQAAAAEAACcQAAAAEMwWRd8uEcsD2un0wJzAorLF1JWcEJ1faISxiioIT3YUO0qCBz0r9tuq/KKewTM/DA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33a6eae8-9918-4a9f-944d-e8a0312db50a", "AQAAAAEAACcQAAAAELu//tbJnFd6xhg+F+F85IvOrtWt+Yc3HRmGxwoI5g0EFHX3FlbahOGdFOfEHsev4w==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(3022), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9275) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9591), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9596) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9598), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9602), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9604) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9606), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9607) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9609), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9614), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9615) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9617), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9619) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9621), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9622) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9624), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9626) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9628), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9632), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9633) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9635), new DateTime(2022, 2, 26, 0, 38, 31, 487, DateTimeKind.Local).AddTicks(9637) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 573, DateTimeKind.Local).AddTicks(832), new DateTime(2022, 2, 26, 0, 38, 31, 573, DateTimeKind.Local).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 573, DateTimeKind.Local).AddTicks(875), new DateTime(2022, 2, 26, 0, 38, 31, 573, DateTimeKind.Local).AddTicks(877) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 573, DateTimeKind.Local).AddTicks(880), new DateTime(2022, 2, 26, 0, 38, 31, 573, DateTimeKind.Local).AddTicks(882) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 573, DateTimeKind.Local).AddTicks(884), new DateTime(2022, 2, 26, 0, 38, 31, 573, DateTimeKind.Local).AddTicks(886) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 573, DateTimeKind.Local).AddTicks(890), new DateTime(2022, 2, 26, 0, 38, 31, 573, DateTimeKind.Local).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5294), new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5343), new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5344) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5347), new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5348) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5351), new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5352) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5354), new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5356) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5358), new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5359) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5361), new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5363) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5365), new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5366) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5369), new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5370) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5372), new DateTime(2022, 2, 26, 0, 38, 31, 571, DateTimeKind.Local).AddTicks(5374) });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 26, 0, 38, 31, 620, DateTimeKind.Local).AddTicks(4206), new DateTime(2022, 2, 26, 0, 38, 31, 620, DateTimeKind.Local).AddTicks(4256) });
        }
    }
}
