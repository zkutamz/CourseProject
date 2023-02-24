using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddAttachmentUrlToAttachmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentUrl",
                table: "Lessons");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 25, 7, 40, 28, 699, DateTimeKind.Local).AddTicks(4850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 24, 19, 44, 11, 30, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.AddColumn<string>(
                name: "AttachmentUrl",
                table: "Attachments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5699adba-5680-4a5d-af92-f7c2c6436200", "AQAAAAEAACcQAAAAEMJRFikf/dcdxL4HYh+wmWW6PXgJT4VhxKHd3evQMb+AUL+31eD8mil2SvohA3PVpg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29999e91-f7e3-47d8-ba47-fbe5b0c227fc", "AQAAAAEAACcQAAAAEAvGonhGZFNSVcmcGOx+UMAPOleEl+m1bMzTqedn1ivnSLNgYg6LoPO3hUZh9HOINg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a5f65a8-7643-487c-9911-5cee2668301e", "AQAAAAEAACcQAAAAEP+rKj4ICKWtrHqNIiMD2JiUzJIg/35pNm85m9/mHpaVHS4ysj9nBVAlJjMJ/9elvQ==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 674, DateTimeKind.Local).AddTicks(18), new DateTime(2022, 1, 25, 7, 40, 28, 674, DateTimeKind.Local).AddTicks(38) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 674, DateTimeKind.Local).AddTicks(79), new DateTime(2022, 1, 25, 7, 40, 28, 674, DateTimeKind.Local).AddTicks(81) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 674, DateTimeKind.Local).AddTicks(83), new DateTime(2022, 1, 25, 7, 40, 28, 674, DateTimeKind.Local).AddTicks(85) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 674, DateTimeKind.Local).AddTicks(87), new DateTime(2022, 1, 25, 7, 40, 28, 674, DateTimeKind.Local).AddTicks(88) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 674, DateTimeKind.Local).AddTicks(90), new DateTime(2022, 1, 25, 7, 40, 28, 674, DateTimeKind.Local).AddTicks(92) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 711, DateTimeKind.Local).AddTicks(8135), new DateTime(2022, 1, 25, 7, 40, 28, 711, DateTimeKind.Local).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(191), new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(5214) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6017), new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6033) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6059), new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6062) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6064), new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6066) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6068), new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6069) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6072), new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6076), new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6077) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6080), new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6082) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6084), new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6085) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6088), new DateTime(2022, 1, 25, 7, 40, 28, 672, DateTimeKind.Local).AddTicks(6089) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentUrl",
                table: "Attachments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 24, 19, 44, 11, 30, DateTimeKind.Local).AddTicks(2878),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 1, 25, 7, 40, 28, 699, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.AddColumn<string>(
                name: "AttachmentUrl",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c267bb18-7cfb-4ffa-8ba3-34f630f8efdd", "AQAAAAEAACcQAAAAECNETCtN2zhNRyZAfVO02VbuoM4CfWicGKLEddpBlRsjfywYLDOuFeuk06LfbxeOmQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "84b185d4-8957-4ddc-a46d-289d5b3f12b4", "AQAAAAEAACcQAAAAEC/b/XUqWNYzJBGhZbOYsGoHYMQsKJ2lCjHyBwo1zbWCzFCUK/+caoRncRHuhH4sWQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c85b55ed-bbc6-4355-9384-3b27b6fde3aa", "AQAAAAEAACcQAAAAEKXZR6dca/zcYsiYSeFEvVB0ew6XjmrCvULKDhbNNgwQw/YpvtSd7qwDm9l7t8pAbQ==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(199), new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(216) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(259), new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(263), new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(265) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(266), new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(268) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(270), new DateTime(2022, 1, 24, 19, 44, 11, 2, DateTimeKind.Local).AddTicks(271) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 44, DateTimeKind.Local).AddTicks(4623), new DateTime(2022, 1, 24, 19, 44, 11, 44, DateTimeKind.Local).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 10, 999, DateTimeKind.Local).AddTicks(9113), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(5889) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6861), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6883) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6903), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6905) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6908), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6912), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6913) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6915), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6916) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6918), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6919) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6921), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6922) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6924), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6925) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6927), new DateTime(2022, 1, 24, 19, 44, 11, 0, DateTimeKind.Local).AddTicks(6928) });
        }
    }
}
