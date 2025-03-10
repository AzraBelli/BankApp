using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BankingCreditSystem.Persistence.Repositories;

public class CreditApplicationRepository : EfRepositoryBase<CreditApplication, Guid, BaseDbContext>, ICreditApplicationRepository
{
    public CreditApplicationRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<IList<CreditApplication>> GetByCustomerIdAsync(Guid customerId)
    {
        return await Context.CreditApplications.Include(c=>c.CreditType).Where(c=>c.CustomerId==customerId).ToListAsync();
    }

    public async Task<IList<CreditApplication>> GetByCreditTypeIdAsync(Guid creditTypeId)
    {
        return await Context.CreditApplications.Include(c=>c.Customer).Where(c=>c.CreditTypeId == creditTypeId).ToListAsync();
    }

    public async Task<IList<CreditApplication>> GetByStatusAsync(CreditApplicationStatus status)
    {
        return await Context.CreditApplications.Include(c=>c.Customer).Include(c=>c.CreditType).Where(c=>c.Status == status).ToListAsync();
    }
    
} 