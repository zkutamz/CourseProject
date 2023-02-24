using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddRelationalDiscussionAndAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 25, 10, 56, 13, 145, DateTimeKind.Local).AddTicks(8728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 25, 7, 40, 28, 699, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discussions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    DiscussionId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Type = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => new { x.DiscussionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Reactions_Discussions_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32604a69-c915-48aa-8a56-60811cd079ff", "AQAAAAEAACcQAAAAEL0m3Qy36DoFdNjUuz+CH6mncKzNdrZAQ13G8gaWqT/FKt2P+7hgY8V5u8QuTzJ3Ow==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2b89d5e-8d9f-4dfe-b780-f3ab3e2507a4", "AQAAAAEAACcQAAAAEHw4YnAnoD7kEBLBDDYp7jaTrjQIpZKq9foOBO3JiQBsYaYbknHSru92LAMr/nSDEw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8403f572-7608-46e9-b00d-296b7431f034", "AQAAAAEAACcQAAAAEFe0dJ6YcVS97KzGKmNsG8sVbKBvZI48oBlwR+IQO+hdx/NnlPj7CRNA1UWXn0zEZQ==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 118, DateTimeKind.Local).AddTicks(6603), new DateTime(2022, 1, 25, 10, 56, 13, 118, DateTimeKind.Local).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 118, DateTimeKind.Local).AddTicks(6686), new DateTime(2022, 1, 25, 10, 56, 13, 118, DateTimeKind.Local).AddTicks(6689) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 118, DateTimeKind.Local).AddTicks(6693), new DateTime(2022, 1, 25, 10, 56, 13, 118, DateTimeKind.Local).AddTicks(6695) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 118, DateTimeKind.Local).AddTicks(6698), new DateTime(2022, 1, 25, 10, 56, 13, 118, DateTimeKind.Local).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 118, DateTimeKind.Local).AddTicks(6703), new DateTime(2022, 1, 25, 10, 56, 13, 118, DateTimeKind.Local).AddTicks(6705) });

            migrationBuilder.UpdateData(
                table: "CertificateTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 158, DateTimeKind.Local).AddTicks(578), new DateTime(2022, 1, 25, 10, 56, 13, 158, DateTimeKind.Local).AddTicks(616) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 115, DateTimeKind.Local).AddTicks(9449), new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(6352) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7502), new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7524) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7559), new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7561) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7565), new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7567) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7571), new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7573) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7576), new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7578) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7581), new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7583) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7586), new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7592), new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7594) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7597), new DateTime(2022, 1, 25, 10, 56, 13, 116, DateTimeKind.Local).AddTicks(7599) });

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_UserId",
                table: "Discussions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_UserId",
                table: "Reactions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Discussions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 25, 7, 40, 28, 699, DateTimeKind.Local).AddTicks(4850),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 1, 25, 10, 56, 13, 145, DateTimeKind.Local).AddTicks(8728));

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
    }
}
