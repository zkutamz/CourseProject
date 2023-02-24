using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddForeginKeyToUserSubscriber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSubcribers_AspNetUsers_UserId",
                table: "UserSubcribers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 14, 2, 37, 162, DateTimeKind.Local).AddTicks(2520),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 24, 14, 32, 32, 813, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1cd67dc8-f6be-4af0-84d6-ded8a58cd3e1", "AQAAAAEAACcQAAAAEN9TLIlmFYcdbIEgDuQNkgaEyZzOHqFChiSB3nHvigwyK/BMKPUbI+2XhOR0L+oq3w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "408f148e-711f-41f9-842b-7129bda922e0", "AQAAAAEAACcQAAAAEJSY0IKywGz5gum9E/DsInbrdfhb+xJSkaY73OF868cFFKtfbZ+RasYapW2oyjYKUQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee1916ba-2812-4217-8b5d-8729ef6c36e9", "AQAAAAEAACcQAAAAELQwDAGLwOLuTmphTOqVxeX7gKFq/Jl80qHkoATr8WLLHv0IEsx3lJYXt7z9qgUkhg==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 53, DateTimeKind.Local).AddTicks(4739), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(1352) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2216), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2225) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2228), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2230) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2234), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2236) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2239), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2242) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2245), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2247) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2250), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2252) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2256), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2258) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2261), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2264) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2266), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2269) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2272), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2277), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2279) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2283), new DateTime(2022, 2, 25, 14, 2, 37, 54, DateTimeKind.Local).AddTicks(2285) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 132, DateTimeKind.Local).AddTicks(7922), new DateTime(2022, 2, 25, 14, 2, 37, 132, DateTimeKind.Local).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 132, DateTimeKind.Local).AddTicks(7953), new DateTime(2022, 2, 25, 14, 2, 37, 132, DateTimeKind.Local).AddTicks(7954) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 132, DateTimeKind.Local).AddTicks(7957), new DateTime(2022, 2, 25, 14, 2, 37, 132, DateTimeKind.Local).AddTicks(7958) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 132, DateTimeKind.Local).AddTicks(7960), new DateTime(2022, 2, 25, 14, 2, 37, 132, DateTimeKind.Local).AddTicks(7961) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 132, DateTimeKind.Local).AddTicks(7967), new DateTime(2022, 2, 25, 14, 2, 37, 132, DateTimeKind.Local).AddTicks(7968) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8254), new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8291) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8295), new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8298), new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8299) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8301), new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8303) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8304), new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8308), new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8309) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8311), new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8312) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8314), new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8315) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8317), new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8318) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8320), new DateTime(2022, 2, 25, 14, 2, 37, 131, DateTimeKind.Local).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 25, 14, 2, 37, 173, DateTimeKind.Local).AddTicks(9593), new DateTime(2022, 2, 25, 14, 2, 37, 173, DateTimeKind.Local).AddTicks(9631) });

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubcribers_AspNetUsers_SubcriberId",
                table: "UserSubcribers",
                column: "SubcriberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubcribers_AspNetUsers_UserId",
                table: "UserSubcribers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSubcribers_AspNetUsers_SubcriberId",
                table: "UserSubcribers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubcribers_AspNetUsers_UserId",
                table: "UserSubcribers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 24, 14, 32, 32, 813, DateTimeKind.Local).AddTicks(9018),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 25, 14, 2, 37, 162, DateTimeKind.Local).AddTicks(2520));

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubcribers_AspNetUsers_UserId",
                table: "UserSubcribers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
