using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddTableCertificateTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CertificateTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    TemplateName = table.Column<string>(nullable: true),
                    TemplpateUrl = table.Column<string>(nullable: true),
                    CertificateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificateTemplates_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CertificateTemplates_CertificateId",
                table: "CertificateTemplates",
                column: "CertificateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificateTemplates");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "39e17849-d475-4ac6-a2aa-525d79572e0a", "AQAAAAEAACcQAAAAEB9DOTZzuw3XJtCtrlfLbdUVXbMzxyFmTyV0nzDNNPZSqIo83xANImLUerlhGBHi0A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "58100eb9-98a8-4bbe-ba81-315a5f250af3", "AQAAAAEAACcQAAAAEEOyWs/h4uavKyWp+LLn1pjhNPhNtIJ0bGdenf9mGTA8EJJkckZWQcL2u8UwqFcjeA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01ccd3fe-d1e6-4d50-b6a4-2889566461db", "AQAAAAEAACcQAAAAEBuoYaVCLrqE8YdwSsXh4VMrd5bDZfqZLSJT8Tdev5Yob/yFIBY3eilLB5snm0w2Hg==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4519), new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4541) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4579), new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4583), new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4586), new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4590), new DateTime(2022, 1, 20, 13, 9, 11, 457, DateTimeKind.Local).AddTicks(4591) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 455, DateTimeKind.Local).AddTicks(5991), new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1042) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1473), new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1493) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1506), new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1508) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1510), new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1512) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1513), new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1515) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1516), new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1518) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1520), new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1522) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1525), new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1527) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1530), new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1533), new DateTime(2022, 1, 20, 13, 9, 11, 456, DateTimeKind.Local).AddTicks(1534) });
        }
    }
}
