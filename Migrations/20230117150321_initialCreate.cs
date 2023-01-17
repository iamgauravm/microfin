using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MicroFIN.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultInstallments = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstallmentSchemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstallmentCount = table.Column<int>(type: "int", nullable: false),
                    RateInterest = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentSchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableFunds = table.Column<double>(type: "float", nullable: false),
                    TotalFunding = table.Column<double>(type: "float", nullable: false),
                    TotalRecovery = table.Column<double>(type: "float", nullable: false),
                    TotalWithdrawal = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    TransDate = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TransType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvestorId = table.Column<int>(type: "int", nullable: false),
                    DairyId = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestorTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActice = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    AccountTypeText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditScore = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableFunds = table.Column<double>(type: "float", nullable: false),
                    TotalFunding = table.Column<double>(type: "float", nullable: false),
                    TotalRecovery = table.Column<double>(type: "float", nullable: false),
                    TotalWithdrawal = table.Column<double>(type: "float", nullable: false),
                    IsCash = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    ParentAccountId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreditScore = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "Dairies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaryNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: true),
                    HasAgent = table.Column<bool>(type: "bit", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    InstallmentSchemeId = table.Column<int>(type: "int", nullable: false),
                    Installment = table.Column<int>(type: "int", nullable: false),
                    LoanAmount = table.Column<double>(type: "float", nullable: false),
                    RecoveryAmount = table.Column<double>(type: "float", nullable: false),
                    TotalPaidAmount = table.Column<double>(type: "float", nullable: false),
                    TotalBalanceAmount = table.Column<double>(type: "float", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AgentId1 = table.Column<int>(type: "int", nullable: true),
                    InvestorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dairies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dairies_Accounts_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dairies_Accounts_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dairies_Agents_AgentId1",
                        column: x => x.AgentId1,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dairies_InstallmentSchemes_InstallmentSchemeId",
                        column: x => x.InstallmentSchemeId,
                        principalTable: "InstallmentSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dairies_Investors_InvestorId",
                        column: x => x.InvestorId,
                        principalTable: "Investors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    LateFee = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    DiaryId = table.Column<int>(type: "int", nullable: true),
                    InvestorId = table.Column<int>(type: "int", nullable: true),
                    FromDiaryId = table.Column<int>(type: "int", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_FromDiaryId",
                        column: x => x.FromDiaryId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_InvestorId",
                        column: x => x.InvestorId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExistingCustomerId = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaryInstallments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstallmentNumber = table.Column<int>(type: "int", nullable: false),
                    InstallmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstallmentAmount = table.Column<double>(type: "float", nullable: false),
                    PaidAmount = table.Column<double>(type: "float", nullable: false),
                    BalanceAmount = table.Column<double>(type: "float", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryInstallments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaryInstallments_Dairies_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "Dairies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaryPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    LateFee = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "DiaryReferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaryId = table.Column<int>(type: "int", nullable: false),
                    FromDiaryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaryReferences_Dairies_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "Dairies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiaryReferences_Dairies_FromDiaryId",
                        column: x => x.FromDiaryId,
                        principalTable: "Dairies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FundTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    LateFee = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    DiaryId = table.Column<int>(type: "int", nullable: false),
                    InvestorId = table.Column<int>(type: "int", nullable: true),
                    FromDiaryId = table.Column<int>(type: "int", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Address", "DefaultInstallments", "IsActive", "Mobile", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 1, "", 120, true, "7974165346", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3795), "Manoj Vishwakarma" });

            migrationBuilder.InsertData(
                table: "InstallmentSchemes",
                columns: new[] { "Id", "InstallmentCount", "IsActive", "ModifiedBy", "ModifiedOn", "Name", "RateInterest" },
                values: new object[,]
                {
                    { 1, 120, true, 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3817), "Scheme-120", 20m },
                    { 2, 117, true, 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3819), "Scheme-117", 20m },
                    { 3, 100, true, 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3822), "Scheme-100", 11.1111m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActice", "ModifiedBy", "ModifiedOn", "Name", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3645), "System Admin", "sysadmin", "sysadmin", "sysadmin" },
                    { 2, true, 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3659), "Admin", "admin", "admin", "admin" },
                    { 3, true, 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3662), "User", "user", "user", "user" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountName", "AccountType", "AccountTypeText", "Address", "AvailableFunds", "BusinessName", "CreatedBy", "CreatedOn", "CreditScore", "FatherName", "IsActive", "IsCash", "IsDefault", "Mobile", "ModifiedBy", "ModifiedOn", "ParentAccountId", "Remarks", "TotalFunding", "TotalRecovery", "TotalWithdrawal" },
                values: new object[,]
                {
                    { 1, "Cash", 1, "Cash", "", 0.0, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3840), 0, "", true, true, false, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3841), 0, "", 0.0, 0.0, 0.0 },
                    { 2, "Investors", 2, "Investor", "", 0.0, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3844), 0, "", true, false, true, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3845), 0, "", 0.0, 0.0, 0.0 },
                    { 3, "Customers", 3, "Customer", "", 0.0, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3847), 0, "", true, false, true, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3847), 0, "", 0.0, 0.0, 0.0 },
                    { 4, "Agents", 4, "Agent", "", 0.0, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3850), 0, "", true, false, true, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3851), 0, "", 0.0, 0.0, 0.0 },
                    { 5, "Expenses", 5, "Expense", "", 0.0, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3852), 0, "", true, false, true, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3853), 0, "", 0.0, 0.0, 0.0 },
                    { 6, "Diaries", 6, "Diary", "", 0.0, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3854), 0, "", true, false, true, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3855), 0, "", 0.0, 0.0, 0.0 },
                    { 7, "M/R and M/K", 2, "Investor", "", 0.0, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3857), 0, "", true, false, false, "7974165346", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3858), 2, "", 0.0, 0.0, 0.0 },
                    { 8, "Manoj Vishwakarma", 4, "Agent", "", 0.0, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3859), 0, "", true, false, false, "7974165346", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3860), 4, "", 0.0, 0.0, 0.0 },
                    { 9, "Other", 5, "Expense", "", 0.0, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3897), 0, "", true, false, false, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3897), 5, "", 0.0, 0.0, 0.0 },
                    { 10, "Purchase", 5, "Expense", "", 0.0, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3899), 0, "", true, false, false, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3900), 5, "", 0.0, 0.0, 0.0 },
                    { 11, "Salary", 5, "Expense", "", 0.0, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3902), 0, "", true, false, false, "", 1, new DateTime(2023, 1, 17, 20, 33, 21, 611, DateTimeKind.Local).AddTicks(3902), 5, "", 0.0, 0.0, 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CreatedBy",
                table: "Accounts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ModifiedBy",
                table: "Accounts",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CustomerId",
                table: "Contacts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreatedBy",
                table: "Customers",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ModifiedBy",
                table: "Customers",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Dairies_AgentId",
                table: "Dairies",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dairies_AgentId1",
                table: "Dairies",
                column: "AgentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Dairies_CustomerId",
                table: "Dairies",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dairies_InstallmentSchemeId",
                table: "Dairies",
                column: "InstallmentSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dairies_InvestorId",
                table: "Dairies",
                column: "InvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryInstallments_DiaryId",
                table: "DiaryInstallments",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryPayments_DiaryId",
                table: "DiaryPayments",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryReferences_DiaryId",
                table: "DiaryReferences",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryReferences_FromDiaryId",
                table: "DiaryReferences",
                column: "FromDiaryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DiaryId",
                table: "Transactions",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromDiaryId",
                table: "Transactions",
                column: "FromDiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_InvestorId",
                table: "Transactions",
                column: "InvestorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DiaryInstallments");

            migrationBuilder.DropTable(
                name: "DiaryPayments");

            migrationBuilder.DropTable(
                name: "DiaryReferences");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "FundTransactions");

            migrationBuilder.DropTable(
                name: "InvestorTransactions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Dairies");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "InstallmentSchemes");

            migrationBuilder.DropTable(
                name: "Investors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
