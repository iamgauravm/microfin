using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroFIN.Core.Migrations
{
    /// <inheritdoc />
    public partial class addcategoryinexpenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 9, 16, 53, 5, 187, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 9, 16, 53, 5, 187, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 9, 16, 53, 5, 187, DateTimeKind.Local).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 9, 16, 53, 5, 187, DateTimeKind.Local).AddTicks(9289));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Expenses");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 4, 0, 28, 33, 585, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 4, 0, 28, 33, 585, DateTimeKind.Local).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 4, 0, 28, 33, 585, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 4, 0, 28, 33, 585, DateTimeKind.Local).AddTicks(6165));
        }
    }
}
