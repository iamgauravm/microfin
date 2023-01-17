using MicroFIN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroFIN.Core;

public interface IMicroFinDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Account> Accounts { get; set; }
    DbSet<Transaction> Transactions { get; set; }
    
    
    DbSet<Contact> Contacts { get; set; }
    DbSet<Diary> Dairies { get; set; }
    DbSet<DiaryInstallment> DiaryInstallments { get; set; }
    DbSet<DiaryReference> DiaryReferences { get; set; }
    DbSet<Expense> Expenses { get; set; }
   
    DbSet<InstallmentScheme> InstallmentSchemes { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}