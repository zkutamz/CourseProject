using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class UpdateAssignmentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignmentUrl",
                table: "Assignments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 24, 14, 32, 32, 813, DateTimeKind.Local).AddTicks(9018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 20, 23, 41, 59, 243, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "NormalizedName",
                value: "INSTRUCTOR");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2633e6f5-b334-4ff4-a2fa-358e6807bcac", "AQAAAAEAACcQAAAAEB1RJFCAGX01vFi13NT7YBFWSnvPin64Gkw4PLCYAkgQdP+Fb7CZbFcAWRf1H/OfHA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65a30ed7-2ee8-4374-9dda-c6fc660ea166", "AQAAAAEAACcQAAAAEPKdywmbv+6f241jUHrOY6u1M0A5akqHp/acUIGfPpiFi5s2CTVH4XjkRr+M3R0iDQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fc86783c-1329-41bf-ad5f-6426899c915c", "AQAAAAEAACcQAAAAEH7AN1WtckT9hdEUsc3Osczb+fvjSSRy8PSQQDphCUOzHiU6prM+mRcgk3DZlaiE2g==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 718, DateTimeKind.Local).AddTicks(6406), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(2797) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3206), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3216) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3219), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3221) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3225), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3227) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3229), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3232) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3234), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3236) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3239), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3241) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3244), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3246) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3249), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3252) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3255), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3257) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3260), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3262) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3265), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3267) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3270), new DateTime(2022, 2, 24, 14, 32, 32, 719, DateTimeKind.Local).AddTicks(3272) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 794, DateTimeKind.Local).AddTicks(8741), new DateTime(2022, 2, 24, 14, 32, 32, 794, DateTimeKind.Local).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 794, DateTimeKind.Local).AddTicks(8774), new DateTime(2022, 2, 24, 14, 32, 32, 794, DateTimeKind.Local).AddTicks(8775) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 794, DateTimeKind.Local).AddTicks(8778), new DateTime(2022, 2, 24, 14, 32, 32, 794, DateTimeKind.Local).AddTicks(8779) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 794, DateTimeKind.Local).AddTicks(8781), new DateTime(2022, 2, 24, 14, 32, 32, 794, DateTimeKind.Local).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 794, DateTimeKind.Local).AddTicks(8785), new DateTime(2022, 2, 24, 14, 32, 32, 794, DateTimeKind.Local).AddTicks(8786) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9001), new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9038) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9043), new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9044) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9047), new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9048) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9050), new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9052) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9054), new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9055) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9057), new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9061), new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9062) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9064), new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9066) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9068), new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9073), new DateTime(2022, 2, 24, 14, 32, 32, 793, DateTimeKind.Local).AddTicks(9074) });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 32, 32, 823, DateTimeKind.Local).AddTicks(7757), new DateTime(2022, 2, 24, 14, 32, 32, 823, DateTimeKind.Local).AddTicks(7793) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 20, 23, 41, 59, 243, DateTimeKind.Local).AddTicks(7666),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 24, 14, 32, 32, 813, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.AddColumn<string>(
                name: "AssignmentUrl",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "NormalizedName",
                value: "Instructor");

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
    }
}
