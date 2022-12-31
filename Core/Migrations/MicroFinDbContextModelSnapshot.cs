﻿// <auto-generated />
using System;
using MicroFIN.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MicroFIN.Core.Migrations
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

            modelBuilder.Entity("MicroFIN.Core.Entities.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DefaultInstallments")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

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

                    b.ToTable("Agents");
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

            modelBuilder.Entity("MicroFIN.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

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

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Dairy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgentId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DailyNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("HasAgent")
                        .HasColumnType("bit");

                    b.Property<int>("Installment")
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

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<double>("TotalBalanceAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Dairies");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.DairyInstallment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BalanceAmount")
                        .HasColumnType("float");

                    b.Property<int>("DairyId")
                        .HasColumnType("int");

                    b.Property<double>("InstallmentAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("InstallmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstallmentNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("PaidAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DairyId");

                    b.ToTable("DairyInstallments");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.DairyReference", b =>
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

                    b.Property<int>("DairyId")
                        .HasColumnType("int");

                    b.Property<int>("FromDairyId")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DairyId");

                    b.HasIndex("FromDairyId");

                    b.ToTable("DairyReferences");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Expense", b =>
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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
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
                            ModifiedOn = new DateTime(2022, 12, 31, 16, 35, 34, 954, DateTimeKind.Local).AddTicks(7009),
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
                            ModifiedOn = new DateTime(2022, 12, 31, 16, 35, 34, 954, DateTimeKind.Local).AddTicks(7025),
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
                            ModifiedOn = new DateTime(2022, 12, 31, 16, 35, 34, 954, DateTimeKind.Local).AddTicks(7027),
                            Name = "User",
                            Password = "user",
                            Role = "user",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Contact", b =>
                {
                    b.HasOne("MicroFIN.Core.Entities.Customer", "Customer")
                        .WithMany("Contacts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Customer", b =>
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

            modelBuilder.Entity("MicroFIN.Core.Entities.Dairy", b =>
                {
                    b.HasOne("MicroFIN.Core.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId");

                    b.HasOne("MicroFIN.Core.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.DairyInstallment", b =>
                {
                    b.HasOne("MicroFIN.Core.Entities.Dairy", null)
                        .WithMany("DairyInstallments")
                        .HasForeignKey("DairyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.DairyReference", b =>
                {
                    b.HasOne("MicroFIN.Core.Entities.Dairy", "Dairy")
                        .WithMany()
                        .HasForeignKey("DairyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicroFIN.Core.Entities.Dairy", "FromDairy")
                        .WithMany()
                        .HasForeignKey("FromDairyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dairy");

                    b.Navigation("FromDairy");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Customer", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("MicroFIN.Core.Entities.Dairy", b =>
                {
                    b.Navigation("DairyInstallments");
                });
#pragma warning restore 612, 618
        }
    }
}
