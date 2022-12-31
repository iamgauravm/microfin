using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroFIN.Core.Migrations
{
    /// <inheritdoc />
    public partial class addremarkscolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dairies_Agents_AgentId",
                table: "Dairies");

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Dairies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Dairies_Agents_AgentId",
                table: "Dairies",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dairies_Agents_AgentId",
                table: "Dairies");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Dairies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 26, 19, 12, 49, 464, DateTimeKind.Local).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 26, 19, 12, 49, 464, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 26, 19, 12, 49, 464, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.AddForeignKey(
                name: "FK_Dairies_Agents_AgentId",
                table: "Dairies",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
