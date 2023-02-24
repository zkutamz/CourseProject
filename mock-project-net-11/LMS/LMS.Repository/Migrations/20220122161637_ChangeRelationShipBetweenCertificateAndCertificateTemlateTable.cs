using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class ChangeRelationShipBetweenCertificateAndCertificateTemlateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Sections_SectionId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateTemplates_Certificates_CertificateId",
                table: "CertificateTemplates");

            migrationBuilder.DropIndex(
                name: "IX_CourseDiscounts_CourseId",
                table: "CourseDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_CertificateTemplates_CertificateId",
                table: "CertificateTemplates");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "CertificateTemplates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 22, 23, 16, 35, 871, DateTimeKind.Local).AddTicks(3511),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 20, 15, 59, 37, 376, DateTimeKind.Local).AddTicks(9611));

            migrationBuilder.AddColumn<int>(
                name: "CertificateTemplateId",
                table: "Certificates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Assignments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "473fce15-8138-494b-a058-62387c7cb2aa", "AQAAAAEAACcQAAAAEK6EUyBaHGDUhq3pDIaEM+mTKzzOsSjZ1C+q91ztsVI5JdWLrQVgA59FDrDxRuxNlQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a57873c0-9bb6-4dbd-b7eb-ed0a859c0b5f", "AQAAAAEAACcQAAAAENQ4ezbzxH8r75a0vWoVDURa351M1dg3qR7qRE0TBdGMaH6FjODNhoMER0GIt+lD0w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4cedebca-3924-425a-a734-471000f074cd", "AQAAAAEAACcQAAAAEG7GcBqupXLEiXGSvDVEf9nyzns+rrTBusyZHX1ShdW0ubyMmhhas+TjB/hATznapw==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(369), new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(428), new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(432), new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(435), new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(438), new DateTime(2022, 1, 22, 23, 16, 35, 851, DateTimeKind.Local).AddTicks(439) });

            migrationBuilder.InsertData(
                table: "CertificateTemplates",
                columns: new[] { "Id", "CreatedAt", "IsDelete", "TemplateName", "TemplpateUrl", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 22, 23, 16, 35, 880, DateTimeKind.Local).AddTicks(9415), false, "Template 1", "\\Certificates\\CertificateTemplates\\templates\\ec022e5c-3c40-404b-90d8-9837f348ac5f.html", new DateTime(2022, 1, 22, 23, 16, 35, 880, DateTimeKind.Local).AddTicks(9443) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 22, 23, 16, 35, 848, DateTimeKind.Local).AddTicks(7291), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(1828) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2492), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2530), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2531) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2533), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2537), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2538) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2540), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2541) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2543), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2545) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2546), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2548) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2550), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2551) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CertificateTemplateId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2553), new DateTime(2022, 1, 22, 23, 16, 35, 849, DateTimeKind.Local).AddTicks(2554) });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscounts_CourseId",
                table: "CourseDiscounts",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CertificateTemplateId",
                table: "Certificates",
                column: "CertificateTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Sections_SectionId",
                table: "Assignments",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_CertificateTemplates_CertificateTemplateId",
                table: "Certificates",
                column: "CertificateTemplateId",
                principalTable: "CertificateTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Sections_SectionId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_CertificateTemplates_CertificateTemplateId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_CourseDiscounts_CourseId",
                table: "CourseDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_CertificateTemplateId",
                table: "Certificates");

            migrationBuilder.DeleteData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CertificateTemplateId",
                table: "Certificates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 20, 15, 59, 37, 376, DateTimeKind.Local).AddTicks(9611),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 1, 22, 23, 16, 35, 871, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "CertificateTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Assignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
                name: "IX_CourseDiscounts_CourseId",
                table: "CourseDiscounts",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CertificateTemplates_CertificateId",
                table: "CertificateTemplates",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Sections_SectionId",
                table: "Assignments",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateTemplates_Certificates_CertificateId",
                table: "CertificateTemplates",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
