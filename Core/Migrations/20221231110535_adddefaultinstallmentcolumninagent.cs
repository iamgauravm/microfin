using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroFIN.Core.Migrations
{
    /// <inheritdoc />
    public partial class adddefaultinstallmentcolumninagent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultInstallments",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 31, 16, 35, 34, 954, DateTimeKind.Local).AddTicks(7009));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 31, 16, 35, 34, 954, DateTimeKind.Local).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 31, 16, 35, 34, 954, DateTimeKind.Local).AddTicks(7027));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultInstallments",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 31, 15, 13, 27, 362, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 31, 15, 13, 27, 362, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 31, 15, 13, 27, 362, DateTimeKind.Local).AddTicks(9653));
        }
    }
}
