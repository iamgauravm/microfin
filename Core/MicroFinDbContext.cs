using System.Reflection;
using MicroFIN.Core.Contracts;
using MicroFIN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroFIN.Core;

public class MicroFinDbContext: DbContext, IMicroFinDbContext
{
    public MicroFinDbContext(DbContextOptions<MicroFinDbContext> options) : base(options)
    {
        Database.SetCommandTimeout(180);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
        
        
      
        
        modelBuilder.Entity<User>().HasData(
            new User {Id = 1,Name = "System Admin",Username = "sysadmin",Password = "sysadmin",Role = "sysadmin",IsActice = true,ModifiedBy = 1, ModifiedOn = DateTime.Now},
            new User {Id = 2,Name = "Admin",Username = "admin",Password = "admin",Role = "admin",IsActice = true,ModifiedBy = 1, ModifiedOn = DateTime.Now},
            new User {Id = 3,Name = "User",Username = "user",Password = "user",Role = "user",IsActice = true,ModifiedBy = 1, ModifiedOn = DateTime.Now}
        );
        
        modelBuilder.Entity<Agent>().HasData(
            new Agent {Id = 1,Name = "Manoj Vishwakarma",Address = "",Mobile = "7974165346",DefaultInstallments = 120,IsActive = true,ModifiedBy = 1, ModifiedOn = DateTime.Now}
        );
        
        modelBuilder.Entity<InstallmentScheme>().HasData(
            new InstallmentScheme {Id = 1,Name = "Scheme-120",InstallmentCount = 120,RateInterest = 20M,IsActive = true,ModifiedBy = 1, ModifiedOn = DateTime.Now},
            new InstallmentScheme {Id = 2,Name = "Scheme-117",InstallmentCount = 117,RateInterest = 20M,IsActive = true,ModifiedBy = 1, ModifiedOn = DateTime.Now},
            new InstallmentScheme {Id = 3,Name = "Scheme-100",InstallmentCount = 100,RateInterest = 11.1111M,IsActive = true,ModifiedBy = 1, ModifiedOn = DateTime.Now}
        );
        
        
        modelBuilder.Entity<Account>().HasData(
            new Account {IsActive =true,Id = (int)AccountType.Default,AccountName = "Cash",AccountType = AccountType.Default,AccountTypeText="Cash",IsCash = true,ParentAccountId = 0,CreatedBy = 1,CreatedOn = DateTime.Now,ModifiedBy = 1,ModifiedOn = DateTime.Now},
            new Account {IsActive =true,Id = (int)AccountType.Investor,AccountName = "Investors",AccountType = AccountType.Investor,AccountTypeText="Investor",IsCash = false, IsDefault = true, ParentAccountId = 0,CreatedBy = 1,CreatedOn = DateTime.Now,ModifiedBy = 1,ModifiedOn = DateTime.Now},
            new Account {IsActive =true,Id = (int)AccountType.Customer,AccountName = "Customers",AccountType = AccountType.Customer,AccountTypeText="Customer",IsCash = false, IsDefault = true, ParentAccountId = 0,CreatedBy = 1,CreatedOn = DateTime.Now,ModifiedBy = 1,ModifiedOn = DateTime.Now},
            new Account {IsActive =true,Id = (int)AccountType.Agent,AccountName = "Agents",AccountType = AccountType.Agent,AccountTypeText="Agent",IsCash = false, IsDefault = true, ParentAccountId = 0,CreatedBy = 1,CreatedOn = DateTime.Now,ModifiedBy = 1,ModifiedOn = DateTime.Now},
            new Account {IsActive =true,Id = (int)AccountType.Expense,AccountName = "Expenses",AccountType = AccountType.Expense,AccountTypeText="Expense",IsCash = false, IsDefault = true, ParentAccountId = 0,CreatedBy = 1,CreatedOn = DateTime.Now,ModifiedBy = 1,ModifiedOn = DateTime.Now},
            new Account {IsActive =true,Id = (int)AccountType.Diary,AccountName = "Diaries",AccountType = AccountType.Diary,AccountTypeText="Diary",IsCash = false, IsDefault = true, ParentAccountId = 0,CreatedBy = 1,CreatedOn = DateTime.Now,ModifiedBy = 1,ModifiedOn = DateTime.Now},
            
            
            new Account {IsActive =true,Id = 7,AccountName = "M/R and M/K",AccountType = AccountType.Investor,AccountTypeText="Investor",Mobile = "7974165346",IsCash = false, IsDefault = false, ParentAccountId = (int)AccountType.Investor,CreatedBy = 1,CreatedOn = DateTime.Now,ModifiedBy = 1,ModifiedOn = DateTime.Now},
            new Account {IsActive =true,Id = 8,AccountName = "Manoj Vishwakarma",AccountType = AccountType.Agent,AccountTypeText="Agent",Mobile = "7974165346",IsCash = false, IsDefault = false, ParentAccountId = (int)AccountType.Agent,CreatedBy = 1,CreatedOn = DateTime.Now,ModifiedBy = 1,ModifiedOn = DateTime.Now},
            new Account {IsActive =true,Id = 9,AccountName = "Other",AccountType = AccountType.Expense,AccountTypeText="Expense",IsCash = false, IsDefault = false, ParentAccountId = (int)AccountType.Expense,CreatedBy = 1,CreatedOn = DateTime.Now,ModifiedBy = 1,ModifiedOn = DateTime.Now},
            new Account {IsActive =true,Id = 10,AccountName = "Purchase",AccountType = AccountType.Expense,AccountTypeText="Expense",IsCash = false, IsDefault = false, ParentAccountId = (int)AccountType.Expense,CreatedBy = 1,CreatedOn = DateTime.Now,ModifiedBy = 1,ModifiedOn = DateTime.Now},
            new Account {IsActive =true,Id = 11,AccountName = "Salary",AccountType = AccountType.Expense,AccountTypeText="Expense",IsCash = false, IsDefault = false, ParentAccountId = (int)AccountType.Expense,CreatedBy = 1,CreatedOn = DateTime.Now,ModifiedBy = 1,ModifiedOn = DateTime.Now}
        );

    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Diary> Dairies { get; set; }
    public virtual DbSet<DiaryInstallment> DiaryInstallments { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    
    
    
   
    public virtual DbSet<Contact> Contacts { get; set; }
    public virtual DbSet<DiaryReference> DiaryReferences { get; set; }
    public virtual DbSet<Expense> Expenses { get; set; }
   
    public virtual DbSet<InstallmentScheme> InstallmentSchemes { get; set; }
    public virtual DbSet<DiaryPayment> DiaryPayments { get; set; }
    public virtual DbSet<InvestorTransaction> InvestorTransactions { get; set; }
    public virtual DbSet<FundTransaction> FundTransactions { get; set; }
    
    
    
    public virtual DbSet<Agent> Agents { get; set; }
    public virtual DbSet<Investor> Investors { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
}