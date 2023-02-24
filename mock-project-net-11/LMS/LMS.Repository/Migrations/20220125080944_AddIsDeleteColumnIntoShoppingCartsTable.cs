using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddIsDeleteColumnIntoShoppingCartsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 25, 15, 9, 42, 733, DateTimeKind.Local).AddTicks(5812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 25, 10, 56, 13, 145, DateTimeKind.Local).AddTicks(8728));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "HelpTopics",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Helps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserLoginTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    Expires = table.Column<DateTime>(nullable: false),
                    Revoked = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLoginTokens_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_HelpTopics_Title",
                table: "HelpTopics",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Helps_UserContent",
                table: "Helps",
                column: "UserContent",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginTokens_AppUserId",
                table: "UserLoginTokens",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoginTokens");

            migrationBuilder.DropIndex(
                name: "IX_HelpTopics_Title",
                table: "HelpTopics");

            migrationBuilder.DropIndex(
                name: "IX_Helps_UserContent",
                table: "Helps");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Helps");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 25, 10, 56, 13, 145, DateTimeKind.Local).AddTicks(8728),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 1, 25, 15, 9, 42, 733, DateTimeKind.Local).AddTicks(5812));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "HelpTopics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

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
        }
    }
}
