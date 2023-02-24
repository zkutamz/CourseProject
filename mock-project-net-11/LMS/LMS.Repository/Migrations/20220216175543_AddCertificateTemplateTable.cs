using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddCertificateTemplateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_CertificateTemplates_CertificateTemplateId",
                table: "Certificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificateTemplates",
                table: "CertificateTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_CertificateTemplateId",
                table: "Certificates");

            migrationBuilder.DeleteData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CertificateTemplates");

            migrationBuilder.DropColumn(
                name: "TemplateName",
                table: "CertificateTemplates");

            migrationBuilder.DropColumn(
                name: "TemplpateUrl",
                table: "CertificateTemplates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 17, 0, 55, 42, 149, DateTimeKind.Local).AddTicks(246),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 16, 23, 25, 9, 397, DateTimeKind.Local).AddTicks(2011));

            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "CertificateTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "CertificateTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificateTemplates",
                table: "CertificateTemplates",
                columns: new[] { "CertificateId", "TemplateId" });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    TemplateName = table.Column<string>(nullable: true),
                    TemplateUrl = table.Column<string>(nullable: true),
                    IsTemplateForCourse = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "CreatedAt", "IsDelete", "IsTemplateForCourse", "TemplateName", "TemplateUrl", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 17, 0, 55, 42, 162, DateTimeKind.Local).AddTicks(1315), false, false, "Template 1", "\\Certificates\\CertificateTemplates\\templates\\ec022e5c-3c40-404b-90d8-9837f348ac5f.html", new DateTime(2022, 2, 17, 0, 55, 42, 162, DateTimeKind.Local).AddTicks(1349) });

            migrationBuilder.CreateIndex(
                name: "IX_CertificateTemplates_TemplateId",
                table: "CertificateTemplates",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateTemplates_Certificates_CertificateId",
                table: "CertificateTemplates",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateTemplates_Templates_TemplateId",
                table: "CertificateTemplates",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificateTemplates_Certificates_CertificateId",
                table: "CertificateTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateTemplates_Templates_TemplateId",
                table: "CertificateTemplates");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificateTemplates",
                table: "CertificateTemplates");

            migrationBuilder.DropIndex(
                name: "IX_CertificateTemplates_TemplateId",
                table: "CertificateTemplates");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "CertificateTemplates");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "CertificateTemplates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 16, 23, 25, 9, 397, DateTimeKind.Local).AddTicks(2011),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 17, 0, 55, 42, 149, DateTimeKind.Local).AddTicks(246));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CertificateTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "TemplateName",
                table: "CertificateTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TemplpateUrl",
                table: "CertificateTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificateTemplates",
                table: "CertificateTemplates",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "53b37d81-9c90-4346-b640-b13ebf445df7", "AQAAAAEAACcQAAAAEOw42+QluVWvFMKtMgWMrlg0oyi4KH/GlUDkVIB0j34f5zre+CXnWi9fAuyMm0hRgw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bc1e85c3-cd3d-4230-ace7-80958ff4a03f", "AQAAAAEAACcQAAAAEBegJBeNiGN2SU2ydTgJGvQb1lw/F0ODydxfINQLwyfNCp2vbohqbMzbCrQp8am2nQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e47fe926-1f43-4e62-bf79-205ccb19efce", "AQAAAAEAACcQAAAAENzItk/Mcj/hp3MAHKThSryolC98tzABJ4I9dOcfgj41uofdfAGHlxL9crO3ckJiLw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 257, DateTimeKind.Local).AddTicks(9462), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4262) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4533), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4538) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4540), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4542) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4544), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4545) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4548), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4549) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4551), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4555), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4557) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4559), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4560) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4563), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4564) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4566), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4568) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4570), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4571) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4573), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4574) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4576), new DateTime(2022, 2, 16, 23, 25, 9, 258, DateTimeKind.Local).AddTicks(4578) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 362, DateTimeKind.Local).AddTicks(2907), new DateTime(2022, 2, 16, 23, 25, 9, 362, DateTimeKind.Local).AddTicks(2944) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 362, DateTimeKind.Local).AddTicks(2950), new DateTime(2022, 2, 16, 23, 25, 9, 362, DateTimeKind.Local).AddTicks(2953) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 362, DateTimeKind.Local).AddTicks(2957), new DateTime(2022, 2, 16, 23, 25, 9, 362, DateTimeKind.Local).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 362, DateTimeKind.Local).AddTicks(2964), new DateTime(2022, 2, 16, 23, 25, 9, 362, DateTimeKind.Local).AddTicks(2967) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 362, DateTimeKind.Local).AddTicks(2971), new DateTime(2022, 2, 16, 23, 25, 9, 362, DateTimeKind.Local).AddTicks(2974) });

            migrationBuilder.InsertData(
                table: "CertificateTemplates",
                columns: new[] { "Id", "CreatedAt", "IsDelete", "TemplateName", "TemplpateUrl", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 2, 16, 23, 25, 9, 409, DateTimeKind.Local).AddTicks(6212), false, "Template 1", "\\Certificates\\CertificateTemplates\\templates\\ec022e5c-3c40-404b-90d8-9837f348ac5f.html", new DateTime(2022, 2, 16, 23, 25, 9, 409, DateTimeKind.Local).AddTicks(6247) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(2623), new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(2679) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3022), new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3028) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3033), new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3036) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3040), new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3043) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3047), new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3049) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3054), new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3057) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3061), new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3064) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3068), new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3074), new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3077) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3081), new DateTime(2022, 2, 16, 23, 25, 9, 360, DateTimeKind.Local).AddTicks(3084) });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CertificateTemplateId",
                table: "Certificates",
                column: "CertificateTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_CertificateTemplates_CertificateTemplateId",
                table: "Certificates",
                column: "CertificateTemplateId",
                principalTable: "CertificateTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
