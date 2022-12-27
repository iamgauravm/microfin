using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroFIN.Core.Migrations
{
    /// <inheritdoc />
    public partial class addexpenseagenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "Dairies");

            migrationBuilder.DropColumn(
                name: "TenureType",
                table: "Dairies");

            migrationBuilder.RenameColumn(
                name: "Tenure",
                table: "Dairies",
                newName: "Installment");

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "DairyInstallments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Dairies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasAgent",
                table: "Dairies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DairyReferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DairyId = table.Column<int>(type: "int", nullable: false),
                    FromDairyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DairyReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DairyReferences_Dairies_DairyId",
                        column: x => x.DairyId,
                        principalTable: "Dairies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DairyReferences_Dairies_FromDairyId",
                        column: x => x.FromDairyId,
                        principalTable: "Dairies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 26, 17, 26, 42, 927, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 26, 17, 26, 42, 927, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ModifiedOn", "Name", "Password", "Role", "Username" },
                values: new object[] { new DateTime(2022, 12, 26, 17, 26, 42, 927, DateTimeKind.Local).AddTicks(8184), "User", "user", "user", "user" });

            migrationBuilder.CreateIndex(
                name: "IX_Dairies_AgentId",
                table: "Dairies",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_DairyReferences_DairyId",
                table: "DairyReferences",
                column: "DairyId");

            migrationBuilder.CreateIndex(
                name: "IX_DairyReferences_FromDairyId",
                table: "DairyReferences",
                column: "FromDairyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dairies_Agents_AgentId",
                table: "Dairies",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dairies_Agents_AgentId",
                table: "Dairies");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "DairyReferences");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Dairies_AgentId",
                table: "Dairies");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "DairyInstallments");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Dairies");

            migrationBuilder.DropColumn(
                name: "HasAgent",
                table: "Dairies");

            migrationBuilder.RenameColumn(
                name: "Installment",
                table: "Dairies",
                newName: "Tenure");

            migrationBuilder.AddColumn<double>(
                name: "InterestRate",
                table: "Dairies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TenureType",
                table: "Dairies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 21, 1, 12, 54, 466, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2022, 12, 21, 1, 12, 54, 466, DateTimeKind.Local).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ModifiedOn", "Name", "Password", "Role", "Username" },
                values: new object[] { new DateTime(2022, 12, 21, 1, 12, 54, 466, DateTimeKind.Local).AddTicks(3160), "Viewer", "viewer", "viewer", "viewer" });
        }
    }
}
