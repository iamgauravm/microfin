﻿using MicroFIN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroFIN.Core.Contracts;

public interface IMicroFinDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Customer> Customers { get; set; }
    DbSet<Contact> Contacts { get; set; }
    DbSet<Dairy> Dairies { get; set; }
    DbSet<DairyInstallment> DairyInstallments { get; set; }
    DbSet<DairyReference> DairyReferences { get; set; }
    DbSet<Expense> Expenses { get; set; }
    DbSet<Agent> Agents { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}