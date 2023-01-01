using System.Reflection;
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
        

    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Contact> Contacts { get; set; }
    public virtual DbSet<Dairy> Dairies { get; set; }
    public virtual DbSet<DairyInstallment> DairyInstallments { get; set; }
    public virtual DbSet<DairyReference> DairyReferences { get; set; }
    public virtual DbSet<Expense> Expenses { get; set; }
    public virtual DbSet<Agent> Agents { get; set; }
}