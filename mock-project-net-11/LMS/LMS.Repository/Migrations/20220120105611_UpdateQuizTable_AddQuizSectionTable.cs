using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class UpdateQuizTable_AddQuizSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Sections_SectionId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_SectionId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Quizzes");

            migrationBuilder.CreateTable(
                name: "QuizSections",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    QuizId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizSections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_QuizSections_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ec476ca8-84dc-4688-a523-984569029797", "AQAAAAEAACcQAAAAENT5x4bilyzO7XFnFe0ha1+Nf4ZHKj8KlMBU2uKVn/W5ZDoKD2DPzojM8PX9rX7izw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b8dbc53-ce9c-4ba9-a687-31cf2ec77e16", "AQAAAAEAACcQAAAAECsRCMIO8aT87/dA1SnDK5ffZ7l47f9Qza+ol6eEfgmroBM2X1+VrqvpL3r023dpiQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3a00c798-6d6d-475b-8a93-f661452f298b", "AQAAAAEAACcQAAAAEMl2VkxuoziqSdmX+YlFD+MxHaOBuJhwZS5M4MkOjwgs4ZKGz/wyxNrMRz7X9nzJag==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4090), new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4107) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4151), new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4155), new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4159), new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4162), new DateTime(2022, 1, 20, 17, 56, 10, 233, DateTimeKind.Local).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 231, DateTimeKind.Local).AddTicks(5745), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1365), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1381) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1396), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1398) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1400), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1401) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1403), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1407), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1409) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1411), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1412) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1414), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1416) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1418), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1422), new DateTime(2022, 1, 20, 17, 56, 10, 232, DateTimeKind.Local).AddTicks(1423) });

            migrationBuilder.CreateIndex(
                name: "IX_QuizSections_QuizId",
                table: "QuizSections",
                column: "QuizId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizSections");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Quizzes_SectionId",
                table: "Quizzes",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Sections_SectionId",
                table: "Quizzes",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
