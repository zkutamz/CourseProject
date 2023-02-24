using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddSelfKeyForDiscussionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 26, 11, 52, 7, 812, DateTimeKind.Local).AddTicks(5553),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 25, 15, 9, 42, 733, DateTimeKind.Local).AddTicks(5812));

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Discussions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "950e88d6-0b15-4d76-ad70-423b633e92f9", "AQAAAAEAACcQAAAAEMml90zdsZtNFF1m7kVL6dW3VGPRRr3Fep35wHNWM4xfC93xqWuxNSG+3P3Wby0lEw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9be0b4a1-3cbc-4e77-8a6b-2a7bfa47d6c5", "AQAAAAEAACcQAAAAELeuW6I8ay6UG2GakF1A8uc0HCjE/T9fuphX3FrVZ5bXrmFn5Vvt8JAibm+YKFasbg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "96d7d8d8-61c9-4ce7-951e-c8c8a59d201a", "AQAAAAEAACcQAAAAEO+SAyp/dhdjtQjZ630yp5UxXtvHKqw6ZOMnrfz4Y/S+VIsOl8UA2IA+fbgrLEnj3g==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 770, DateTimeKind.Local).AddTicks(9238), new DateTime(2022, 1, 26, 11, 52, 7, 770, DateTimeKind.Local).AddTicks(9259) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 770, DateTimeKind.Local).AddTicks(9263), new DateTime(2022, 1, 26, 11, 52, 7, 770, DateTimeKind.Local).AddTicks(9265) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 770, DateTimeKind.Local).AddTicks(9267), new DateTime(2022, 1, 26, 11, 52, 7, 770, DateTimeKind.Local).AddTicks(9269) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 770, DateTimeKind.Local).AddTicks(9271), new DateTime(2022, 1, 26, 11, 52, 7, 770, DateTimeKind.Local).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 770, DateTimeKind.Local).AddTicks(9274), new DateTime(2022, 1, 26, 11, 52, 7, 770, DateTimeKind.Local).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 826, DateTimeKind.Local).AddTicks(9230), new DateTime(2022, 1, 26, 11, 52, 7, 826, DateTimeKind.Local).AddTicks(9269) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(399), new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7071) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7710), new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7718) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7722), new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7727), new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7733), new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7735) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7738), new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7743), new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7745) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7748), new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7753), new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7755) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7758), new DateTime(2022, 1, 26, 11, 52, 7, 769, DateTimeKind.Local).AddTicks(7761) });

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_ParentId",
                table: "Discussions",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Discussions_ParentId",
                table: "Discussions",
                column: "ParentId",
                principalTable: "Discussions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Discussions_ParentId",
                table: "Discussions");

            migrationBuilder.DropIndex(
                name: "IX_Discussions_ParentId",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Discussions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 25, 15, 9, 42, 733, DateTimeKind.Local).AddTicks(5812),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 1, 26, 11, 52, 7, 812, DateTimeKind.Local).AddTicks(5553));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56465e21-5205-45eb-9c98-bebea80a4b1a", "AQAAAAEAACcQAAAAEDEuPq/OTGdpzBFZPXcYrtY/ASvJ0iv0PTaQ3Z/zIzoFNKesr0S9Xy/veE4+xLCEXA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "46cbd383-9160-4ef9-9160-73bf9513042f", "AQAAAAEAACcQAAAAEEZLh5JoPQdQelnD9dNpfLR3htvjTmHQRA0zxh7WADGRD/qf2Q41EUqJgwZ9D8aVTg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e72b89ee-0a39-448d-862f-71e2b1756b01", "AQAAAAEAACcQAAAAEMB5Pft9KwqU7fZQsZihDiMZkMyn+dbidezz1K4ydOXKhITUgwcblVrJcdFXM8NM+A==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(4997), new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5056), new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5061) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5066), new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5074), new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5078) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5083), new DateTime(2022, 1, 25, 15, 9, 42, 691, DateTimeKind.Local).AddTicks(5086) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 756, DateTimeKind.Local).AddTicks(9728), new DateTime(2022, 1, 25, 15, 9, 42, 756, DateTimeKind.Local).AddTicks(9825) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(121), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5924), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5928) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5931), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5932) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5936), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5938) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5941), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5943) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5945), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5949), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5951) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5953), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5954) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5956), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5958) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5960), new DateTime(2022, 1, 25, 15, 9, 42, 689, DateTimeKind.Local).AddTicks(5961) });
        }
    }
}
