using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class CreateTableAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Size = table.Column<long>(nullable: false),
                    LessonId = table.Column<int>(nullable: true),
                    AssignmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "841a48d5-54e6-4ef5-889b-09dec34e31f5", "AQAAAAEAACcQAAAAEFs7GubzsZViCKmTOeXfhIerdwJO3oKXy8cMkOCdcXE1Daf0zGJ2CEuARGZvfJl9UQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "caa8bd54-908f-454d-9e9f-c971858c4f3c", "AQAAAAEAACcQAAAAEBf1P4g/OND+mo/sf8ybABFEd5GKMfmUZgeo45pumVuiNjXKFXWImKrHU3G7NZxCCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd483b02-8bad-4fc9-9fa8-de724ce5cedb", "AQAAAAEAACcQAAAAEIkwEVD5Htk391Ilm99x61ZUScmP5mdBZ8+XkCsWTwXmMVXOJFrYcijuXRKic7IKBg==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 737, DateTimeKind.Local).AddTicks(4197), new DateTime(2022, 1, 21, 13, 34, 39, 737, DateTimeKind.Local).AddTicks(4215) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 737, DateTimeKind.Local).AddTicks(4258), new DateTime(2022, 1, 21, 13, 34, 39, 737, DateTimeKind.Local).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 737, DateTimeKind.Local).AddTicks(4263), new DateTime(2022, 1, 21, 13, 34, 39, 737, DateTimeKind.Local).AddTicks(4265) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 737, DateTimeKind.Local).AddTicks(4268), new DateTime(2022, 1, 21, 13, 34, 39, 737, DateTimeKind.Local).AddTicks(4269) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 737, DateTimeKind.Local).AddTicks(4272), new DateTime(2022, 1, 21, 13, 34, 39, 737, DateTimeKind.Local).AddTicks(4274) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 735, DateTimeKind.Local).AddTicks(4153), new DateTime(2022, 1, 21, 13, 34, 39, 735, DateTimeKind.Local).AddTicks(9725) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(241), new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(276), new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(278) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(280), new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(282) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(284), new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(286) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(288), new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(290) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(292), new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(294) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(296), new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(298) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(300), new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(304), new DateTime(2022, 1, 21, 13, 34, 39, 736, DateTimeKind.Local).AddTicks(305) });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AssignmentId",
                table: "Attachments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_LessonId",
                table: "Attachments",
                column: "LessonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65848557-d444-4285-8a54-900414075d7e", "AQAAAAEAACcQAAAAEA7qSvd3EjLa6ZphomWYWRLwR0BEblDKU1dz/VFzc4VYZeUdx4hU/E7ywYhpUvs3Pg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "31005b76-ea1f-4929-b4a8-9a56918bc541", "AQAAAAEAACcQAAAAEL9UYDNXU1Qzcntl1PEEw49rjEfeDg43xU3cIDwJhfH1q5sCz6XcoEXE+ktAW3pvZA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b9e43226-6b13-4356-950f-d3bd930e1c92", "AQAAAAEAACcQAAAAEFnnrAVI2Ss+nkXfiJIhGU/kEfNyCcvjcmLsTmq88PUQF+UMlQIBTM2KC1xZideNmg==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8698), new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8728) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8781), new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8789), new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8791) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8794), new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8796) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8798), new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 659, DateTimeKind.Local).AddTicks(9903), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(7221) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9131), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9248), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9254) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9261), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9270), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9275) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9281), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9285) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9290), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9301), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9305) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9311), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9315) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9320), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9325) });
        }
    }
}
