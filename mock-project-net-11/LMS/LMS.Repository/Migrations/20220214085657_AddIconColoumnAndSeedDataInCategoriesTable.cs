using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddIconColoumnAndSeedDataInCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 14, 15, 56, 55, 521, DateTimeKind.Local).AddTicks(4057),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 14, 10, 45, 51, 430, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Categories",
                nullable: true);

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
                columns: new[] { "CreatedAt", "Icon", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 421, DateTimeKind.Local).AddTicks(5752), "BsCode", "Development", new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1184) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Icon", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1476), "BsBarChart", "Business", new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1481) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Icon", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1484), "AiOutlineAccountBook", "Finance & Accounting", new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1485) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Icon", "IsDelete", "Name", "ParentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 13, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1521), "HiOutlineAcademicCap", false, "Teaching & Academics", null, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1522) },
                    { 12, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1516), "IoMusicalNotesOutline", false, "Music", null, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1519) },
                    { 4, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1488), "HiOutlineDesktopComputer", false, "IT & Software", null, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1489) },
                    { 10, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1509), "MdOutlinePhotoCamera", false, "Photography", null, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1511) },
                    { 11, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1513), "IoFitnessOutline", false, "Health & Fitness", null, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1514) },
                    { 8, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1503), "AiOutlineBarChart", false, "Marketing", null, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1504) },
                    { 7, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1498), "RiRulerLine", false, "Design", null, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1501) },
                    { 5, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1491), "HiOutlineOfficeBuilding", false, "Office Productivity", null, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1493) },
                    { 9, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1506), "GiLifeInTheBalance", false, "Lifestyle", null, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1507) },
                    { 6, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1495), "AiOutlineBook", false, "Personal Development", null, new DateTime(2022, 2, 14, 15, 56, 55, 422, DateTimeKind.Local).AddTicks(1496) }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 14, 10, 45, 51, 430, DateTimeKind.Local).AddTicks(9968),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 14, 15, 56, 55, 521, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "128dd4bc-7e08-458c-bf19-a9706ae48792", "AQAAAAEAACcQAAAAECpj9DwB+3B3uGH/eETWOj9s0Fg4YMuJEcRS99x5DCOpHCErax1us4QwvdUHjh/4VA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "750abd8b-b3bc-4420-b997-5913aa380e86", "AQAAAAEAACcQAAAAENptd/8KfJBmsxmoQFKCflZi8SWFV3wx3EO9mk08VB6wnhpPjoQC/8bFxrZqfztY9A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "195ab0d4-ab1b-4d26-9379-72910ea20bcb", "AQAAAAEAACcQAAAAEKFY1CUclL2K/zrxrfuxoPkreOJPHjUAK191MicJnUUbvJM7gvTvDy34kJWYeNkKjA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game Design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Language Learning", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 402, DateTimeKind.Local).AddTicks(664), new DateTime(2022, 2, 14, 10, 45, 51, 402, DateTimeKind.Local).AddTicks(694) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 402, DateTimeKind.Local).AddTicks(704), new DateTime(2022, 2, 14, 10, 45, 51, 402, DateTimeKind.Local).AddTicks(707) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 402, DateTimeKind.Local).AddTicks(710), new DateTime(2022, 2, 14, 10, 45, 51, 402, DateTimeKind.Local).AddTicks(712) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 402, DateTimeKind.Local).AddTicks(715), new DateTime(2022, 2, 14, 10, 45, 51, 402, DateTimeKind.Local).AddTicks(717) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 402, DateTimeKind.Local).AddTicks(720), new DateTime(2022, 2, 14, 10, 45, 51, 402, DateTimeKind.Local).AddTicks(722) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 442, DateTimeKind.Local).AddTicks(8485), new DateTime(2022, 2, 14, 10, 45, 51, 442, DateTimeKind.Local).AddTicks(8536) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 399, DateTimeKind.Local).AddTicks(2843), new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(2954) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(3989), new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4001) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4006), new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4014), new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4018) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4022), new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4025) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4029), new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4032) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4036), new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4039) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4043), new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4046) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4050), new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4053) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4057), new DateTime(2022, 2, 14, 10, 45, 51, 400, DateTimeKind.Local).AddTicks(4345) });
        }
    }
}
