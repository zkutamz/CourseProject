using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddParentIdColumnInCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Categories",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb59b9ee-ac4d-42e3-aab4-5962fc733db7", "AQAAAAEAACcQAAAAEE8JA2ODSQgWNVzvaGhsdE1XBu7pRDiogpSjAXjo8YifVqt6HajzWA+jTy/VP8oV6A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a286555-2f94-4ce0-98bd-cfd3d7579e9e", "AQAAAAEAACcQAAAAELOELKO+b1JhdbJ8IAfwS5kePprAayMWredqzMOwirXPg0q5tbZ7lqlm6vpuQuRZJw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "34ed9622-860f-40c6-b88f-e5253e074159", "AQAAAAEAACcQAAAAELxWe0dH3XMEBGJ5SyVeZqpFM0adWB36KtzT6YS5YFQMV2mWfa5hD5ebUr7VVC6pvw==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 965, DateTimeKind.Local).AddTicks(1297), new DateTime(2022, 1, 20, 16, 31, 27, 965, DateTimeKind.Local).AddTicks(1359) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 965, DateTimeKind.Local).AddTicks(1498), new DateTime(2022, 1, 20, 16, 31, 27, 965, DateTimeKind.Local).AddTicks(1505) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 965, DateTimeKind.Local).AddTicks(1512), new DateTime(2022, 1, 20, 16, 31, 27, 965, DateTimeKind.Local).AddTicks(1516) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 965, DateTimeKind.Local).AddTicks(1522), new DateTime(2022, 1, 20, 16, 31, 27, 965, DateTimeKind.Local).AddTicks(1526) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 965, DateTimeKind.Local).AddTicks(1531), new DateTime(2022, 1, 20, 16, 31, 27, 965, DateTimeKind.Local).AddTicks(1536) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(723), new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(8486) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9230), new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9258) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9277), new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9283), new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9285) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9288), new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9293), new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9298), new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9303), new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9305) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9308), new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9313), new DateTime(2022, 1, 20, 16, 31, 27, 961, DateTimeKind.Local).AddTicks(9316) });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51a5cc4e-4ddd-4c2a-ad64-fcf1b99ecd30", "AQAAAAEAACcQAAAAEGty7gWB4Iishn8Td5zU8ul86p4hoELl9mmClL2z7o+JJWaVXj3bc4paRuW0HpiaUg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "056f6821-ede4-454c-a115-6606fa0c9387", "AQAAAAEAACcQAAAAEGUVP+jcFbFwcImSK+3hBpgxiZ700u4p4HX7AEcHerfe7Fhj5Ms42Pk4o8yGrraAvw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56e5bff9-91b9-4419-a7ed-0ababff3c609", "AQAAAAEAACcQAAAAEP8qpCrF4mK+dwm500oEYAnrJ0rpNBLwncdiVYQVlMZ4X5F1js+3o34rYYwiKw6P/g==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(446), new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(470) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(522), new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(525) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(529), new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(531) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(533), new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(535) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(539), new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 537, DateTimeKind.Local).AddTicks(3331), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(1151) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2156), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2178) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2194), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2196) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2199), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2202) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2206), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2208) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2210), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2213) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2215), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2220), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2222) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2225), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2227) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2230), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2232) });
        }
    }
}
