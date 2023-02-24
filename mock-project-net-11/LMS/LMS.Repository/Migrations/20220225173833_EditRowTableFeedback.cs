using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class EditRowTableFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SreenShot",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Feedbacks",
                newName: "Email");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 26, 0, 38, 31, 606, DateTimeKind.Local).AddTicks(7485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 14, 2, 37, 162, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.AddColumn<string>(
                name: "ScreenShot",
                table: "Feedbacks",
                type: "nvarchar(255)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScreenShot",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Feedbacks",
                newName: "Title");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 14, 2, 37, 162, DateTimeKind.Local).AddTicks(2520),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 26, 0, 38, 31, 606, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.AddColumn<string>(
                name: "SreenShot",
                table: "Feedbacks",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
