using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddRelationShipBetweenCourseAndCertificateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Certificates_CertificateId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CertificateId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "Courses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 16, 23, 25, 9, 397, DateTimeKind.Local).AddTicks(2011),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 14, 15, 56, 55, 521, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Certificates",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsForCourse",
                table: "Certificates",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 16, 23, 25, 9, 409, DateTimeKind.Local).AddTicks(6212), new DateTime(2022, 2, 16, 23, 25, 9, 409, DateTimeKind.Local).AddTicks(6247) });

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
                name: "IX_Certificates_CourseId",
                table: "Certificates",
                column: "CourseId",
                unique: true,
                filter: "[CourseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Courses_CourseId",
                table: "Certificates",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Courses_CourseId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_CourseId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "IsForCourse",
                table: "Certificates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 14, 15, 56, 55, 521, DateTimeKind.Local).AddTicks(4057),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 16, 23, 25, 9, 397, DateTimeKind.Local).AddTicks(2011));

            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4bc59288-e6db-44e5-be9c-0c84010a618b", "AQAAAAEAACcQAAAAEO0mUQRNo9+gD2lDhaIR/YipQY/eCrSKyeGS/TFSJ+KsOAj7ddaof5hHQaacbUx6lg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af9c0795-cb89-4dc4-8496-c3637df258a7", "AQAAAAEAACcQAAAAEHXOJN8pWJoESN5hNUDLjsXa3zXpTOgTkO6FY1qJ0QVRrLr2H/X80mK4YQyjhOfRWg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dfe1a3bf-2464-4b22-8618-cad28054f183", "AQAAAAEAACcQAAAAEPbgrUop182stgfMdCY68xz2vhgXLEhWopxx9QZ91k36TNPOd1ghfLlkErYMSD+wnw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 421, DateTimeKind.Local).AddTicks(5752), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1184) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1476), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1481) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1484), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1485) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1488), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1491), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1493) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1495), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1496) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1498), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1501) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1503), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1504) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1506), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1509), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1511) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1513), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1514) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1516), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1519) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1521), new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1522) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 494, DateTimeKind.Local).AddTicks(8928), new DateTime(2022, 2, 14, 15, 56, 55, 494, DateTimeKind.Local).AddTicks(8957) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 494, DateTimeKind.Local).AddTicks(8962), new DateTime(2022, 2, 14, 15, 56, 55, 494, DateTimeKind.Local).AddTicks(8963) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 494, DateTimeKind.Local).AddTicks(8966), new DateTime(2022, 2, 14, 15, 56, 55, 494, DateTimeKind.Local).AddTicks(8967) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 494, DateTimeKind.Local).AddTicks(8969), new DateTime(2022, 2, 14, 15, 56, 55, 494, DateTimeKind.Local).AddTicks(8971) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 494, DateTimeKind.Local).AddTicks(8973), new DateTime(2022, 2, 14, 15, 56, 55, 494, DateTimeKind.Local).AddTicks(8974) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 534, DateTimeKind.Local).AddTicks(7465), new DateTime(2022, 2, 14, 15, 56, 55, 534, DateTimeKind.Local).AddTicks(7502) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4263), new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4298) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4477), new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4480) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4482), new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4484) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4486), new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4487) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4489), new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4491) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4496), new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4498) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4500), new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4501) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4503), new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4505) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4507), new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4508) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4510), new DateTime(2022, 2, 14, 15, 56, 55, 493, DateTimeKind.Local).AddTicks(4512) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CertificateId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CertificateId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CertificateId",
                table: "Courses",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Certificates_CertificateId",
                table: "Courses",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
