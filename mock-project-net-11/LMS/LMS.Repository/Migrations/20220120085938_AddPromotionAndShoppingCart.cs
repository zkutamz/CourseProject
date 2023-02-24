using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class AddPromotionAndShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CouponCode",
                table: "OrderHeaders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDiscounts_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoursePromotions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Tittle = table.Column<string>(nullable: true),
                    VendorId = table.Column<int>(nullable: false),
                    CouponCode = table.Column<string>(maxLength: 8, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePromotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePromotions_AspNetUsers_VendorId",
                        column: x => x.VendorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 1, 20, 15, 59, 37, 376, DateTimeKind.Local).AddTicks(9611)),
                    IsPending = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "471e29c8-edb2-4db5-a8da-2b773e643cf9", "AQAAAAEAACcQAAAAEOQMPqyqmSOCxIRReb7pomx4CIZW8rfeqTu6Vs8B3Wue9qzm9drkySmG0YHPNlpSxw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e8d6743-05fd-495c-9f61-cf23904eae12", "AQAAAAEAACcQAAAAEEbIdUa9qubgltG42VQGXlPKZmBBMzZL/JXNs1e8ttI3Lssz09rXFXS8/rCnjXREtA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e745a93b-4d98-4260-9609-1352aa380aa1", "AQAAAAEAACcQAAAAECs4mNnJ7hc8LsWeePoFv4W6EotoNz9xf959IjCEsyJ6XlKi0pWe1iXEFRVDR0OVCA==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 354, DateTimeKind.Local).AddTicks(3734), new DateTime(2022, 1, 20, 15, 59, 37, 354, DateTimeKind.Local).AddTicks(3754) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 354, DateTimeKind.Local).AddTicks(3800), new DateTime(2022, 1, 20, 15, 59, 37, 354, DateTimeKind.Local).AddTicks(3802) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 354, DateTimeKind.Local).AddTicks(3805), new DateTime(2022, 1, 20, 15, 59, 37, 354, DateTimeKind.Local).AddTicks(3807) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 354, DateTimeKind.Local).AddTicks(3809), new DateTime(2022, 1, 20, 15, 59, 37, 354, DateTimeKind.Local).AddTicks(3811) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 354, DateTimeKind.Local).AddTicks(3814), new DateTime(2022, 1, 20, 15, 59, 37, 354, DateTimeKind.Local).AddTicks(3816) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(1639), new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(8891) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9500), new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9518) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9533), new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9538), new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9570), new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9572) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9574), new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9579), new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9583), new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9585) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9588), new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9592), new DateTime(2022, 1, 20, 15, 59, 37, 352, DateTimeKind.Local).AddTicks(9594) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_CouponCode",
                table: "OrderHeaders",
                column: "CouponCode");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscounts_CourseId",
                table: "CourseDiscounts",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePromotions_CouponCode",
                table: "CoursePromotions",
                column: "CouponCode");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePromotions_VendorId",
                table: "CoursePromotions",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CourseId",
                table: "ShoppingCarts",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_CoursePromotions_CouponCode",
                table: "OrderHeaders",
                column: "CouponCode",
                principalTable: "CoursePromotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_CoursePromotions_CouponCode",
                table: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "CourseDiscounts");

            migrationBuilder.DropTable(
                name: "CoursePromotions");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeaders_CouponCode",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "CouponCode",
                table: "OrderHeaders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51a5cc4e-4ddd-4c2a-ad64-fcf1b99ecd30", "AQAAAAEAACcQAAAAEGty7gWB4Iishn8Td5zU8ul86p4hoELl9mmClL2z7o+JJWaVXj3bc4paRuW0HpiaUg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "056f6821-ede4-454c-a115-6606fa0c9387", "AQAAAAEAACcQAAAAEGUVP+jcFbFwcImSK+3hBpgxiZ700u4p4HX7AEcHerfe7Fhj5Ms42Pk4o8yGrraAvw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56e5bff9-91b9-4419-a7ed-0ababff3c609", "AQAAAAEAACcQAAAAEP8qpCrF4mK+dwm500oEYAnrJ0rpNBLwncdiVYQVlMZ4X5F1js+3o34rYYwiKw6P/g==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(446), new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(470) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(522), new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(525) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(529), new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(531) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(533), new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(535) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(539), new DateTime(2022, 1, 20, 14, 48, 25, 540, DateTimeKind.Local).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 537, DateTimeKind.Local).AddTicks(3331), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(1151) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2156), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2178) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2194), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2196) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2199), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2202) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2206), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2208) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2210), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2213) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2215), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2220), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2222) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2225), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2227) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2230), new DateTime(2022, 1, 20, 14, 48, 25, 538, DateTimeKind.Local).AddTicks(2232) });
        }
    }
}
