using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddColumnToAppUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 11, 9, 3, 13, 110, DateTimeKind.Local).AddTicks(4933),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 26, 11, 52, 7, 812, DateTimeKind.Local).AddTicks(5553));

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordReset",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResetToken",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetTokenExpires",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Verified",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "304e45f3-cd44-4c21-afc0-662e31c6b3af", "AQAAAAEAACcQAAAAEPP3APT6veNIpeyRuMDxbUPFUdqaJA2wIqYObelDO3brMVkvwL+PIO02Cq5FPJ0tUw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7e2d5eb-c7fc-4a7e-b49e-44e93f140421", "AQAAAAEAACcQAAAAEHbAWgp2lm+PRE+ueZ1hhUgL+bysnxuIb88rA+FB993DQaqrZdjdxkltXELoKHm+iA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "94038612-d4e9-4f93-834e-45ee9a80c161", "AQAAAAEAACcQAAAAEJxgpZxX5OQLMozxf02hKKaQf7w6dblRRJ+YxxiKbwLTDgHOX7jgLnHS2qjvSX3sOw==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 84, DateTimeKind.Local).AddTicks(6107), new DateTime(2022, 2, 11, 9, 3, 13, 84, DateTimeKind.Local).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 84, DateTimeKind.Local).AddTicks(6148), new DateTime(2022, 2, 11, 9, 3, 13, 84, DateTimeKind.Local).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 84, DateTimeKind.Local).AddTicks(6155), new DateTime(2022, 2, 11, 9, 3, 13, 84, DateTimeKind.Local).AddTicks(6156) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 84, DateTimeKind.Local).AddTicks(6158), new DateTime(2022, 2, 11, 9, 3, 13, 84, DateTimeKind.Local).AddTicks(6160) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 84, DateTimeKind.Local).AddTicks(6162), new DateTime(2022, 2, 11, 9, 3, 13, 84, DateTimeKind.Local).AddTicks(6163) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 128, DateTimeKind.Local).AddTicks(9714), new DateTime(2022, 2, 11, 9, 3, 13, 128, DateTimeKind.Local).AddTicks(9763) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 82, DateTimeKind.Local).AddTicks(7981), new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(3539) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4014), new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4019) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4022), new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4024) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4026), new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4028) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4031), new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4032) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4034), new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4038), new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4039) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4042), new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4043) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4045), new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4047) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4049), new DateTime(2022, 2, 11, 9, 3, 13, 83, DateTimeKind.Local).AddTicks(4050) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordReset",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ResetToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ResetTokenExpires",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VerificationToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 26, 11, 52, 7, 812, DateTimeKind.Local).AddTicks(5553),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 11, 9, 3, 13, 110, DateTimeKind.Local).AddTicks(4933));

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
        }
    }
}
