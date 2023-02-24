using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Repository.Migrations
{
    public partial class ChangeDefaultValueColumnCourseStatusToDraftInCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CourseStatus",
                table: "Courses",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65848557-d444-4285-8a54-900414075d7e", "AQAAAAEAACcQAAAAEA7qSvd3EjLa6ZphomWYWRLwR0BEblDKU1dz/VFzc4VYZeUdx4hU/E7ywYhpUvs3Pg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "31005b76-ea1f-4929-b4a8-9a56918bc541", "AQAAAAEAACcQAAAAEL9UYDNXU1Qzcntl1PEEw49rjEfeDg43xU3cIDwJhfH1q5sCz6XcoEXE+ktAW3pvZA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b9e43226-6b13-4356-950f-d3bd930e1c92", "AQAAAAEAACcQAAAAEFnnrAVI2Ss+nkXfiJIhGU/kEfNyCcvjcmLsTmq88PUQF+UMlQIBTM2KC1xZideNmg==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8698), new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8728) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8781), new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8789), new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8791) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8794), new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8796) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8798), new DateTime(2022, 1, 21, 11, 40, 9, 663, DateTimeKind.Local).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 659, DateTimeKind.Local).AddTicks(9903), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(7221) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9131), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9248), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9254) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9261), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9270), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9275) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9281), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9285) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9290), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9301), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9305) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9311), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9315) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9320), new DateTime(2022, 1, 21, 11, 40, 9, 661, DateTimeKind.Local).AddTicks(9325) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CourseStatus",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5bd6a6a1-6a94-4265-b27e-529f71f0df8f", "AQAAAAEAACcQAAAAEHneWs6HQwOpusOyfjTReLDLN0w79uzAZWMBH5oOXY6NyZAzxuf4oJwoU6MLL5knjQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d8232a2-c2ad-41a0-ad1e-f27bfa903fbc", "AQAAAAEAACcQAAAAEGwqdF5We8CBEU8qL3xtYHA/Jq7d4N+2+YfZrFOvIMKhNQh9B2+xOogssLqHimabzw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b0223cf-859c-408c-8d5a-d22791dee8f6", "AQAAAAEAACcQAAAAEIXkBUjtjFJul1UgFVa8vVXaWLLwKswBapI5wOKGIahSjbW+3UvFVhBQYsOoXAAc2g==" });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3353), new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3372) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3411), new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3413) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3415), new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3417) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3418), new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "CertificateCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3422), new DateTime(2022, 1, 20, 19, 19, 50, 601, DateTimeKind.Local).AddTicks(3423) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 599, DateTimeKind.Local).AddTicks(4794), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(633), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(649) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(662), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(663) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(666), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(668) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(670), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(671) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(673), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(677), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(678) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(680), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(682) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(684), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(685) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(687), new DateTime(2022, 1, 20, 19, 19, 50, 600, DateTimeKind.Local).AddTicks(689) });
        }
    }
}
