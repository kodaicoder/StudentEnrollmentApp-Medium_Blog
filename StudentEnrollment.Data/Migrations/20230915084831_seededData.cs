using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class seededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d3ef660-17b3-4d1e-9034-843e8c71d49b", null, "User", "USER" },
                    { "84698797-57f1-47f9-9a37-bf3d11b44c43", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreateBy", "CreatedDate", "Credits", "Title", "UpdateBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "SYSTEM", new DateTime(2023, 9, 15, 15, 48, 30, 921, DateTimeKind.Local).AddTicks(2326), 3, "Course number 1", "SYSTEM", new DateTime(2023, 9, 15, 15, 48, 30, 921, DateTimeKind.Local).AddTicks(2344) },
                    { 2, "SYSTEM", new DateTime(2023, 9, 15, 15, 48, 30, 921, DateTimeKind.Local).AddTicks(2348), 5, "Course number 2", "SYSTEM", new DateTime(2023, 9, 15, 15, 48, 30, 921, DateTimeKind.Local).AddTicks(2348) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d3ef660-17b3-4d1e-9034-843e8c71d49b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84698797-57f1-47f9-9a37-bf3d11b44c43");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
