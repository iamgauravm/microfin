using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroFIN.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Customers_CustomerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Dairies_Agents_AgentId1",
                table: "Dairies");

            migrationBuilder.DropForeignKey(
                name: "FK_Dairies_Investors_InvestorId",
                table: "Dairies");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DiaryPayments");

            migrationBuilder.DropTable(
                name: "FundTransactions");

            migrationBuilder.DropTable(
                name: "InvestorTransactions");

            migrationBuilder.DropTable(
                name: "Investors");

            migrationBuilder.DropIndex(
                name: "IX_Dairies_AgentId1",
                table: "Dairies");

            migrationBuilder.DropIndex(
                name: "IX_Dairies_InvestorId",
                table: "Dairies");

            migrationBuilder.DropColumn(
                name: "AgentId1",
                table: "Dairies");

            migrationBuilder.DropColumn(
                name: "InvestorId",
                table: "Dairies");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7560), new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7563) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7566), new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7567) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7569), new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7570) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7572), new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7572) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7574), new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7575) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7576), new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7577) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7615), new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7616) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7618), new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7619) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7621), new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7621) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7623), new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7624) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7625), new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7626) });

            migrationBuilder.UpdateData(
                table: "InstallmentSchemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "InstallmentSchemes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "InstallmentSchemes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.CreateIndex(
                name: "IX_Dairies_AccountId",
                table: "Dairies",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_CustomerId",
                table: "Contacts",
                column: "CustomerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dairies_Accounts_AccountId",
                table: "Dairies",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_CustomerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Dairies_Accounts_AccountId",
                table: "Dairies");

            migrationBuilder.DropIndex(
                name: "IX_Dairies_AccountId",
                table: "Dairies");

            migrationBuilder.AddColumn<int>(
                name: "AgentId1",
                table: "Dairies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvestorId",
                table: "Dairies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultInstallments = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditScore = table.Column<int>(type: "int", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiaryPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    LateFee = table.Column<double>(type: "float", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaryPayments_Dairies_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "Dairies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableFunds = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalFunding = table.Column<double>(type: "float", nullable: false),
                    TotalRecovery = table.Column<double>(type: "float", nullable: false),
                    TotalWithdrawal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestorTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DairyId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvestorId = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransDate = table.Column<DateTime>(type: "date", nullable: false),
                    TransType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestorTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FundTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaryId = table.Column<int>(type: "int", nullable: false),
                    FromDiaryId = table.Column<int>(type: "int", nullable: true),
                    InvestorId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    LateFee = table.Column<double>(type: "float", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    TransDate = table.Column<DateTime>(type: "date", nullable: false),
                    TransType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundTransactions_Dairies_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "Dairies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundTransactions_Dairies_FromDiaryId",
                        column: x => x.FromDiaryId,
                        principalTable: "Dairies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FundTransactions_Investors_InvestorId",
                        column: x => x.InvestorId,
                        principalTable: "Investors",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3840), new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3841) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3844), new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3845) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3847), new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3850), new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3851) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3852), new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3853) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3854), new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3857), new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3858) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3859), new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3897), new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3897) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3899), new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3902), new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3902) });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Address", "DefaultInstallments", "IsActive", "Mobile", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 1, "", 120, true, "7974165346", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3795), "Manoj Vishwakarma" });

            migrationBuilder.UpdateData(
                table: "InstallmentSchemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "InstallmentSchemes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "InstallmentSchemes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedOn",
                value: new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3662));

            migrationBuilder.CreateIndex(
                name: "IX_Dairies_AgentId1",
                table: "Dairies",
                column: "AgentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Dairies_InvestorId",
                table: "Dairies",
                column: "InvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreatedBy",
                table: "Customers",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ModifiedBy",
                table: "Customers",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryPayments_DiaryId",
                table: "DiaryPayments",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FundTransactions_DiaryId",
                table: "FundTransactions",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FundTransactions_FromDiaryId",
                table: "FundTransactions",
                column: "FromDiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FundTransactions_InvestorId",
                table: "FundTransactions",
                column: "InvestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Customers_CustomerId",
                table: "Contacts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dairies_Agents_AgentId1",
                table: "Dairies",
                column: "AgentId1",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dairies_Investors_InvestorId",
                table: "Dairies",
                column: "InvestorId",
                principalTable: "Investors",
                principalColumn: "Id");
        }
    }
}
