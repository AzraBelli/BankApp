using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BankingCreditSystem.Persistence.Context;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
    public DbSet<CreditType> CreditTypes { get; set; }
    public DbSet<CreditApplication> CreditApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
} 