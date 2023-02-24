using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AllowNullForCertificateCategoryInCertificateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_CertificateCategories_CertificateCategoryId",
                table: "Certificates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 20, 15, 59, 52, 518, DateTimeKind.Local).AddTicks(2275),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 17, 0, 55, 42, 149, DateTimeKind.Local).AddTicks(246));

            migrationBuilder.AlterColumn<int>(
                name: "CertificateCategoryId",
                table: "Certificates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d6deb55b-9c72-4fee-a986-5cf5e880665c", "AQAAAAEAACcQAAAAEIkGk7WJCG+w0X/Ap7nN0NYO1Sn77elMLFoClk3toTtRc5FfxQkctvEhjR90FpEhjw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bfcada1c-d954-4be7-b730-7618baeed930", "AQAAAAEAACcQAAAAENMoLSzj0UG3RWkRFof/Y8ezTkSuXbi4dLW5w9ZzLxkEF5RJMXflk4ESbTvp1RreQg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "57b75932-5e34-49d3-a187-777f23011d3b", "AQAAAAEAACcQAAAAEJJHXQDWUNnJ0NNqfFqneu6PGQK8Ja7YQiFdHKf0FVqcJfPBVsZIYB2J6hd46uj2WQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 402, DateTimeKind.Local).AddTicks(7567), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1716), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1732) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1739), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1744) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1751), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1755) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1762), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1773), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1777) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1783), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1788) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1794), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1798) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1804), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1809) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1815), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1819) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1825), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1830) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1836), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1841) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1847), new DateTime(2022, 2, 20, 15, 59, 52, 404, DateTimeKind.Local).AddTicks(1851) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 483, DateTimeKind.Local).AddTicks(2849), new DateTime(2022, 2, 20, 15, 59, 52, 483, DateTimeKind.Local).AddTicks(2868) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 483, DateTimeKind.Local).AddTicks(2872), new DateTime(2022, 2, 20, 15, 59, 52, 483, DateTimeKind.Local).AddTicks(2874) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 483, DateTimeKind.Local).AddTicks(2876), new DateTime(2022, 2, 20, 15, 59, 52, 483, DateTimeKind.Local).AddTicks(2878) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 483, DateTimeKind.Local).AddTicks(2880), new DateTime(2022, 2, 20, 15, 59, 52, 483, DateTimeKind.Local).AddTicks(2882) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 483, DateTimeKind.Local).AddTicks(2883), new DateTime(2022, 2, 20, 15, 59, 52, 483, DateTimeKind.Local).AddTicks(2885) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(1867), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(1906) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2093), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2097) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2100), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2101) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2103), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2107), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2109) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2111), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2113) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2115), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2119), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2121) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2123), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2124) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2126), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2128) });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 536, DateTimeKind.Local).AddTicks(4338), new DateTime(2022, 2, 20, 15, 59, 52, 536, DateTimeKind.Local).AddTicks(4381) });

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_CertificateCategories_CertificateCategoryId",
                table: "Certificates",
                column: "CertificateCategoryId",
                principalTable: "CertificateCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_CertificateCategories_CertificateCategoryId",
                table: "Certificates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 17, 0, 55, 42, 149, DateTimeKind.Local).AddTicks(246),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 20, 15, 59, 52, 518, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.AlterColumn<int>(
                name: "CertificateCategoryId",
                table: "Certificates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "657acd49-1c6d-443a-a4c5-8b8a7f1bf648", "AQAAAAEAACcQAAAAEBmZiaS+N/el0pDU/PKppDyRaPzQtIjiigAtcp7P9B7xdakf1bbMhXvMgdAYrDr89A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b9a204a6-ec40-44f7-b819-93792ab68485", "AQAAAAEAACcQAAAAEMVigsvlNEsJGQZd3Nyh+sWzX9HVPlwY0hqOvjGoJ1oMnq7x3lKNC7K9BmDn4Agkpw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "66e538fe-92bd-49ec-886e-7789d6553f48", "AQAAAAEAACcQAAAAEM0YR34na79G7rL4e6eUnyDIaBSQcrkEwENW5LZyptI2cqVJ74R/35OwF2BrAWKZ1Q==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(3011), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8455), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8462), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8464) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8466), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8467) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8469), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8471) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8473), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8476), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8478) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8479), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8481) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8483), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8486), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8488) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8489), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8491) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8493), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8494) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8496), new DateTime(2022, 2, 17, 0, 55, 42, 38, DateTimeKind.Local).AddTicks(8498) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 115, DateTimeKind.Local).AddTicks(4444), new DateTime(2022, 2, 17, 0, 55, 42, 115, DateTimeKind.Local).AddTicks(4464) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 115, DateTimeKind.Local).AddTicks(4469), new DateTime(2022, 2, 17, 0, 55, 42, 115, DateTimeKind.Local).AddTicks(4471) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 115, DateTimeKind.Local).AddTicks(4474), new DateTime(2022, 2, 17, 0, 55, 42, 115, DateTimeKind.Local).AddTicks(4476) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 115, DateTimeKind.Local).AddTicks(4479), new DateTime(2022, 2, 17, 0, 55, 42, 115, DateTimeKind.Local).AddTicks(4481) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 115, DateTimeKind.Local).AddTicks(4484), new DateTime(2022, 2, 17, 0, 55, 42, 115, DateTimeKind.Local).AddTicks(4486) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(896), new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(932) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1163), new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1167) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1169), new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1172) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1174), new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1176) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1179), new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1181) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1183), new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1185) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1188), new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1192), new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1194) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1197), new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1198) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1201), new DateTime(2022, 2, 17, 0, 55, 42, 114, DateTimeKind.Local).AddTicks(1203) });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 17, 0, 55, 42, 162, DateTimeKind.Local).AddTicks(1315), new DateTime(2022, 2, 17, 0, 55, 42, 162, DateTimeKind.Local).AddTicks(1349) });

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_CertificateCategories_CertificateCategoryId",
                table: "Certificates",
                column: "CertificateCategoryId",
                principalTable: "CertificateCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
