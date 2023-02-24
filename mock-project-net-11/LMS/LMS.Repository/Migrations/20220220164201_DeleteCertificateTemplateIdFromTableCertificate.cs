using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class DeleteCertificateTemplateIdFromTableCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertificateTemplateId",
                table: "Certificates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 20, 23, 41, 59, 243, DateTimeKind.Local).AddTicks(7666),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 20, 15, 59, 52, 518, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c351b635-395f-4136-8897-8d7065ac81ee", "AQAAAAEAACcQAAAAECp5uj7bWd24dZKEj2OUJajhqces4pOm4RJgy6ICNWsFWd91WZ3z9QLOClCxDIrEgg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c13aca1-4f2a-440c-bb1e-356f924b499b", "AQAAAAEAACcQAAAAEOspo4kLPgf/bfCBNoJQmG6VBXmLXtyAu9aVQaDnm/S9Z0G2x3vcRXuAofplSvwTeA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d16c605-8f6e-4e49-9aa8-99f028c48bf4", "AQAAAAEAACcQAAAAEA9SfwijWcGvVrQm7BV4NvyXOoIZZRUYdxJ9S5DE1apeEKx57K+scTi8L+l2PvEjIg==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 153, DateTimeKind.Local).AddTicks(5985), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1164), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1169) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1172), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1173) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1175), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1177) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1179), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1182), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1184) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1186), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1188) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1190), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1191) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1193), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1194) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1196), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1198) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1200), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1201) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1203), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1205) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1207), new DateTime(2022, 2, 20, 23, 41, 59, 154, DateTimeKind.Local).AddTicks(1208) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 221, DateTimeKind.Local).AddTicks(3369), new DateTime(2022, 2, 20, 23, 41, 59, 221, DateTimeKind.Local).AddTicks(3398) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 221, DateTimeKind.Local).AddTicks(3401), new DateTime(2022, 2, 20, 23, 41, 59, 221, DateTimeKind.Local).AddTicks(3403) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 221, DateTimeKind.Local).AddTicks(3405), new DateTime(2022, 2, 20, 23, 41, 59, 221, DateTimeKind.Local).AddTicks(3407) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 221, DateTimeKind.Local).AddTicks(3409), new DateTime(2022, 2, 20, 23, 41, 59, 221, DateTimeKind.Local).AddTicks(3411) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 221, DateTimeKind.Local).AddTicks(3413), new DateTime(2022, 2, 20, 23, 41, 59, 221, DateTimeKind.Local).AddTicks(3415) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2539), new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2576) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2581), new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2583) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2585), new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2586) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2589), new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2591) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2593), new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2594) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2596), new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2598) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2600), new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2601) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2603), new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2605) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2607), new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2608) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2611), new DateTime(2022, 2, 20, 23, 41, 59, 220, DateTimeKind.Local).AddTicks(2612) });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 23, 41, 59, 256, DateTimeKind.Local).AddTicks(2768), new DateTime(2022, 2, 20, 23, 41, 59, 256, DateTimeKind.Local).AddTicks(2802) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 20, 15, 59, 52, 518, DateTimeKind.Local).AddTicks(2275),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 20, 23, 41, 59, 243, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.AddColumn<int>(
                name: "CertificateTemplateId",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(1867), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(1906) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2093), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2097) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2100), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2101) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2103), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2107), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2109) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2111), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2113) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2115), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2119), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2121) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2123), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2124) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2126), new DateTime(2022, 2, 20, 15, 59, 52, 482, DateTimeKind.Local).AddTicks(2128) });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 20, 15, 59, 52, 536, DateTimeKind.Local).AddTicks(4338), new DateTime(2022, 2, 20, 15, 59, 52, 536, DateTimeKind.Local).AddTicks(4381) });
        }
    }
}
