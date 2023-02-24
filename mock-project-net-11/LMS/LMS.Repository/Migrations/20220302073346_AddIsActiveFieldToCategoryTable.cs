using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddIsActiveFieldToCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 2, 14, 33, 44, 179, DateTimeKind.Local).AddTicks(4151),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 2, 8, 51, 4, 870, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Categories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "68ee69b7-ce33-4a6f-b7b9-b722fdb05710", "AQAAAAEAACcQAAAAEGjpcxCYfHvcE8ailErLb2X/Ce6OdRt/XMkAcg/oiOlMcVwZnuZdExma/R6kTuzVXg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2f93f7c9-7314-4f5a-a3b2-ebec1199ff1e", "AQAAAAEAACcQAAAAEAW0CYODs01wwNZMijasLBoOSqc7DrWxSXnXiRP/nls+/4Wrvb6bi91ngpBQ2gpwVg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a43ca766-7060-4a2e-99b8-deb67569adb8", "AQAAAAEAACcQAAAAEC8DFpnUKUMt7PgdcANzKxw75pN+yXRN2hf+Q7JBGWZG2GCWUSFUTKBQ4dJKc2SJ7g==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(560), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7216) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7500), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7505) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7507), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7509) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7511), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7514) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7517), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7518) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7520), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7522) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7524), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7529) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7531), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7535), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7538), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7540) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7541), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7543) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7545), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7546) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7549), new DateTime(2022, 3, 2, 14, 33, 44, 54, DateTimeKind.Local).AddTicks(7551) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 146, DateTimeKind.Local).AddTicks(3967), new DateTime(2022, 3, 2, 14, 33, 44, 146, DateTimeKind.Local).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 146, DateTimeKind.Local).AddTicks(4003), new DateTime(2022, 3, 2, 14, 33, 44, 146, DateTimeKind.Local).AddTicks(4004) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 146, DateTimeKind.Local).AddTicks(4007), new DateTime(2022, 3, 2, 14, 33, 44, 146, DateTimeKind.Local).AddTicks(4008) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 146, DateTimeKind.Local).AddTicks(4010), new DateTime(2022, 3, 2, 14, 33, 44, 146, DateTimeKind.Local).AddTicks(4012) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 146, DateTimeKind.Local).AddTicks(4014), new DateTime(2022, 3, 2, 14, 33, 44, 146, DateTimeKind.Local).AddTicks(4015) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2412), new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2458) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2463), new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2465) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2467), new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2471), new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2475), new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2476) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2478), new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2480) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2482), new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2483) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2485), new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2487) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2489), new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2490) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2492), new DateTime(2022, 3, 2, 14, 33, 44, 145, DateTimeKind.Local).AddTicks(2494) });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 2, 14, 33, 44, 194, DateTimeKind.Local).AddTicks(7763), new DateTime(2022, 3, 2, 14, 33, 44, 194, DateTimeKind.Local).AddTicks(7816) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 2, 8, 51, 4, 870, DateTimeKind.Local).AddTicks(7969),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 3, 2, 14, 33, 44, 179, DateTimeKind.Local).AddTicks(4151));

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
    }
}
