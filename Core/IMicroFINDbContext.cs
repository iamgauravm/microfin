using MicroFIN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroFIN.Core;

public interface IMicroFinDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Account> Accounts { get; set; }
    DbSet<Transaction> Transactions { get; set; }
    
    
    DbSet<Customer> Customers { get; set; }
    DbSet<Contact> Contacts { get; set; }
    DbSet<Diary> Dairies { get; set; }
    DbSet<DiaryInstallment> DiaryInstallments { get; set; }
    DbSet<DiaryReference> DiaryReferences { get; set; }
    DbSet<Expense> Expenses { get; set; }
    DbSet<Agent> Agents { get; set; }
    DbSet<Investor> Investors { get; set; }
    DbSet<InstallmentScheme> InstallmentSchemes { get; set; }
    DbSet<DiaryPayment> DiaryPayments { get; set; }
    DbSet<InvestorTransaction> InvestorTransactions { get; set; }
    DbSet<FundTransaction> FundTransactions { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}