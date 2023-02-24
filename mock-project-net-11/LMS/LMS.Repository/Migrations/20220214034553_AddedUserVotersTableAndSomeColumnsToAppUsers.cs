using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddedUserVotersTableAndSomeColumnsToAppUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 14, 10, 45, 51, 430, DateTimeKind.Local).AddTicks(9968),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 11, 9, 3, 13, 110, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.AddColumn<int>(
                name: "DownVote",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileViewCount",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpVote",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserVoters",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    VoterId = table.Column<int>(nullable: false),
                    IsUpvote = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVoters", x => new { x.UserId, x.VoterId });
                    table.ForeignKey(
                        name: "FK_UserVoters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVoters");

            migrationBuilder.DropColumn(
                name: "DownVote",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileViewCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpVote",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 11, 9, 3, 13, 110, DateTimeKind.Local).AddTicks(4933),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 14, 10, 45, 51, 430, DateTimeKind.Local).AddTicks(9968));

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
    }
}
