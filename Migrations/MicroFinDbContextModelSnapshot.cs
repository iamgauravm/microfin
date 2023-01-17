﻿// <auto-generated />
using System;
using MicroFIN.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MicroFIN.Migrations
{
    [DbContext(typeof(MicroFinDbContext))]
    partial class MicroFinDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MicroFIN.Core.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<string>("AccountTypeText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AvailableFunds")
                        .HasColumnType("float");

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreditScore")
                        .HasColumnType("int");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCash")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParentAccountId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalFunding")
                        .HasColumnType("float");

                    b.Property<double>("TotalRecovery")
                        .HasColumnType("float");

                    b.Property<double>("TotalWithdrawal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountName = "Cash",
                            AccountType = 1,
                            AccountTypeText = "Cash",
                            Address = "",
                            AvailableFunds = 0.0,
                            BusinessName = "",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7560),
                            CreditScore = 0,
                            FatherName = "",
                            IsActive = true,
                            IsCash = true,
                            IsDefault = false,
                            Mobile = "",
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7563),
                            ParentAccountId = 0,
                            Remarks = "",
                            TotalFunding = 0.0,
                            TotalRecovery = 0.0,
                            TotalWithdrawal = 0.0
                        },
                        new
                        {
                            Id = 2,
                            AccountName = "Investors",
                            AccountType = 2,
                            AccountTypeText = "Investor",
                            Address = "",
                            AvailableFunds = 0.0,
                            BusinessName = "",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7566),
                            CreditScore = 0,
                            FatherName = "",
                            IsActive = true,
                            IsCash = false,
                            IsDefault = true,
                            Mobile = "",
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7567),
                            ParentAccountId = 0,
                            Remarks = "",
                            TotalFunding = 0.0,
                            TotalRecovery = 0.0,
                            TotalWithdrawal = 0.0
                        },
                        new
                        {
                            Id = 3,
                            AccountName = "Customers",
                            AccountType = 3,
                            AccountTypeText = "Customer",
                            Address = "",
                            AvailableFunds = 0.0,
                            BusinessName = "",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7569),
                            CreditScore = 0,
                            FatherName = "",
                            IsActive = true,
                            IsCash = false,
                            IsDefault = true,
                            Mobile = "",
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7570),
                            ParentAccountId = 0,
                            Remarks = "",
                            TotalFunding = 0.0,
                            TotalRecovery = 0.0,
                            TotalWithdrawal = 0.0
                        },
                        new
                        {
                            Id = 4,
                            AccountName = "Agents",
                            AccountType = 4,
                            AccountTypeText = "Agent",
                            Address = "",
                            AvailableFunds = 0.0,
                            BusinessName = "",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7572),
                            CreditScore = 0,
                            FatherName = "",
                            IsActive = true,
                            IsCash = false,
                            IsDefault = true,
                            Mobile = "",
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7572),
                            ParentAccountId = 0,
                            Remarks = "",
                            TotalFunding = 0.0,
                            TotalRecovery = 0.0,
                            TotalWithdrawal = 0.0
                        },
                        new
                        {
                            Id = 5,
                            AccountName = "Expenses",
                            AccountType = 5,
                            AccountTypeText = "Expense",
                            Address = "",
                            AvailableFunds = 0.0,
                            BusinessName = "",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7574),
                            CreditScore = 0,
                            FatherName = "",
                            IsActive = true,
                            IsCash = false,
                            IsDefault = true,
                            Mobile = "",
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7575),
                            ParentAccountId = 0,
                            Remarks = "",
                            TotalFunding = 0.0,
                            TotalRecovery = 0.0,
                            TotalWithdrawal = 0.0
                        },
                        new
                        {
                            Id = 6,
                            AccountName = "Diaries",
                            AccountType = 6,
                            AccountTypeText = "Diary",
                            Address = "",
                            AvailableFunds = 0.0,
                            BusinessName = "",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7576),
                            CreditScore = 0,
                            FatherName = "",
                            IsActive = true,
                            IsCash = false,
                            IsDefault = true,
                            Mobile = "",
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7577),
                            ParentAccountId = 0,
                            Remarks = "",
                            TotalFunding = 0.0,
                            TotalRecovery = 0.0,
                            TotalWithdrawal = 0.0
                        },
                        new
                        {
                            Id = 7,
                            AccountName = "M/R and M/K",
                            AccountType = 2,
                            AccountTypeText = "Investor",
                            Address = "",
                            AvailableFunds = 0.0,
                            BusinessName = "",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7615),
                            CreditScore = 0,
                            FatherName = "",
                            IsActive = true,
                            IsCash = false,
                            IsDefault = false,
                            Mobile = "7974165346",
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7616),
                            ParentAccountId = 2,
                            Remarks = "",
                            TotalFunding = 0.0,
                            TotalRecovery = 0.0,
                            TotalWithdrawal = 0.0
                        },
                        new
                        {
                            Id = 8,
                            AccountName = "Manoj Vishwakarma",
                            AccountType = 4,
                            AccountTypeText = "Agent",
                            Address = "",
                            AvailableFunds = 0.0,
                            BusinessName = "",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7618),
                            CreditScore = 0,
                            FatherName = "",
                            IsActive = true,
                            IsCash = false,
                            IsDefault = false,
                            Mobile = "7974165346",
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7619),
                            ParentAccountId = 4,
                            Remarks = "",
                            TotalFunding = 0.0,
                            TotalRecovery = 0.0,
                            TotalWithdrawal = 0.0
                        },
                        new
                        {
                            Id = 9,
                            AccountName = "Other",
                            AccountType = 5,
                            AccountTypeText = "Expense",
                            Address = "",
                            AvailableFunds = 0.0,
                            BusinessName = "",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7621),
                            CreditScore = 0,
                            FatherName = "",
                            IsActive = true,
                            IsCash = false,
                            IsDefault = false,
                            Mobile = "",
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7621),
                            ParentAccountId = 5,
                            Remarks = "",
                            TotalFunding = 0.0,
                            TotalRecovery = 0.0,
                            TotalWithdrawal = 0.0
                        },
                        new
                        {
                            Id = 10,
                            AccountName = "Purchase",
                            AccountType = 5,
                            AccountTypeText = "Expense",
                            Address = "",
                            AvailableFunds = 0.0,
                            BusinessName = "",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7623),
                            CreditScore = 0,
                            FatherName = "",
                            IsActive = true,
                            IsCash = false,
                            IsDefault = false,
                            Mobile = "",
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7624),
                            ParentAccountId = 5,
                            Remarks = "",
                            TotalFunding = 0.0,
                            TotalRecovery = 0.0,
                            TotalWithdrawal = 0.0
                        },
                        new
                        {
                            Id = 11,
                            AccountName = "Salary",
                            AccountType = 5,
                            AccountTypeText = "Expense",
                            Address = "",
                            AvailableFunds = 0.0,
                            BusinessName = "",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7625),
                            CreditScore = 0,
                            FatherName = "",
                            IsActive = true,
                            IsCash = false,
                            IsDefault = false,
                            Mobile = "",
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7626),
                            ParentAccountId = 5,
                            Remarks = "",
                            TotalFunding = 0.0,
                            TotalRecovery = 0.0,
                            TotalWithdrawal = 0.0
                        });
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("ExistingCustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Diary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("AgentId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DiaryNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool?>("HasAgent")
                        .HasColumnType("bit");

                    b.Property<int>("Installment")
                        .HasColumnType("int");

                    b.Property<int>("InstallmentSchemeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<double>("LoanAmount")
                        .HasColumnType("float");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("RecoveryAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<double>("TotalBalanceAmount")
                        .HasColumnType("float");

                    b.Property<double>("TotalPaidAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AgentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InstallmentSchemeId");

                    b.ToTable("Dairies");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.DiaryInstallment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BalanceAmount")
                        .HasColumnType("float");

                    b.Property<int>("DiaryId")
                        .HasColumnType("int");

                    b.Property<double>("InstallmentAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("InstallmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstallmentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("PaidAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DiaryId");

                    b.ToTable("DiaryInstallments");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.DiaryReference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiaryId")
                        .HasColumnType("int");

                    b.Property<int>("FromDiaryId")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DiaryId");

                    b.HasIndex("FromDiaryId");

                    b.ToTable("DiaryReferences");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.InstallmentScheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InstallmentCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RateInterest")
                        .HasColumnType("decimal(10, 4)");

                    b.HasKey("Id");

                    b.ToTable("InstallmentSchemes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InstallmentCount = 120,
                            IsActive = true,
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7536),
                            Name = "Scheme-120",
                            RateInterest = 20m
                        },
                        new
                        {
                            Id = 2,
                            InstallmentCount = 117,
                            IsActive = true,
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7539),
                            Name = "Scheme-117",
                            RateInterest = 20m
                        },
                        new
                        {
                            Id = 3,
                            InstallmentCount = 100,
                            IsActive = true,
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7542),
                            Name = "Scheme-100",
                            RateInterest = 11.1111m
                        });
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DiaryId")
                        .HasColumnType("int");

                    b.Property<int?>("FromDiaryId")
                        .HasColumnType("int");

                    b.Property<int?>("InvestorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<double>("LateFee")
                        .HasColumnType("float");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<DateTime>("TransDate")
                        .HasColumnType("date");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<string>("TransactionTypeText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiaryId");

                    b.HasIndex("FromDiaryId");

                    b.HasIndex("InvestorId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActice")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActice = true,
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7349),
                            Name = "System Admin",
                            Password = "sysadmin",
                            Role = "sysadmin",
                            Username = "sysadmin"
                        },
                        new
                        {
                            Id = 2,
                            IsActice = true,
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7362),
                            Name = "Admin",
                            Password = "admin",
                            Role = "admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 3,
                            IsActice = true,
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 18, 1, 53, 14, 67, DateTimeKind.Local).AddTicks(7364),
                            Name = "User",
                            Password = "user",
                            Role = "user",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Account", b =>
                {
                    b.HasOne("MicroFIN.Core.Entities.User", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("MicroFIN.Core.Entities.User", "ModifyByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedBy");

                    b.Navigation("CreateByUser");

                    b.Navigation("ModifyByUser");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Contact", b =>
                {
                    b.HasOne("MicroFIN.Core.Entities.Account", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Diary", b =>
                {
                    b.HasOne("MicroFIN.Core.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicroFIN.Core.Entities.Account", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId");

                    b.HasOne("MicroFIN.Core.Entities.Account", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicroFIN.Core.Entities.InstallmentScheme", "InstallmentScheme")
                        .WithMany()
                        .HasForeignKey("InstallmentSchemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Agent");

                    b.Navigation("Customer");

                    b.Navigation("InstallmentScheme");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.DiaryInstallment", b =>
                {
                    b.HasOne("MicroFIN.Core.Entities.Diary", null)
                        .WithMany("DiaryInstallments")
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.DiaryReference", b =>
                {
                    b.HasOne("MicroFIN.Core.Entities.Diary", "Diary")
                        .WithMany()
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicroFIN.Core.Entities.Diary", "FromDiary")
                        .WithMany()
                        .HasForeignKey("FromDiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diary");

                    b.Navigation("FromDiary");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Transaction", b =>
                {
                    b.HasOne("MicroFIN.Core.Entities.Account", "Diary")
                        .WithMany()
                        .HasForeignKey("DiaryId");

                    b.HasOne("MicroFIN.Core.Entities.Account", "FromDiary")
                        .WithMany()
                        .HasForeignKey("FromDiaryId");

                    b.HasOne("MicroFIN.Core.Entities.Account", "Investor")
                        .WithMany()
                        .HasForeignKey("InvestorId");

                    b.Navigation("Diary");

                    b.Navigation("FromDiary");

                    b.Navigation("Investor");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Diary", b =>
                {
                    b.Navigation("DiaryInstallments");
                });
#pragma warning restore 612, 618
        }
    }
}
