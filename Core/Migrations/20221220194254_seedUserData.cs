using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MicroFIN.Core.Migrations
{
    /// <inheritdoc />
    public partial class seedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActice", "ModifiedBy", "ModifiedOn", "Name", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2022, 12, 21, 1, 12, 54, 466, DateTimeKind.Local).AddTicks(3142), "System Admin", "sysadmin", "sysadmin", "sysadmin" },
                    { 2, true, 1, new DateTime(2022, 12, 21, 1, 12, 54, 466, DateTimeKind.Local).AddTicks(3159), "Admin", "admin", "admin", "admin" },
                    { 3, true, 1, new DateTime(2022, 12, 21, 1, 12, 54, 466, DateTimeKind.Local).AddTicks(3160), "Viewer", "viewer", "viewer", "viewer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
