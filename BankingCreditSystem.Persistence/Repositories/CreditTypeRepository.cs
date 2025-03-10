using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BankingCreditSystem.Persistence.Repositories;

public class CreditTypeRepository : EfRepositoryBase<CreditType, Guid, BaseDbContext>, ICreditTypeRepository
{
    public CreditTypeRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<IList<CreditType>> GetByCustomerTypesAsync(CustomerType customerType)
    {
        return await Context.CreditTypes.Where(ct => ct.CustomerType == customerType).ToListAsync();
    }

    public async Task<IList<CreditType>> GetSubCreditTypesAsync(Guid parentCreditTypeId)
    {
        return await Context.CreditTypes.Where(ct => ct.ParentCreditTypeId == parentCreditTypeId).ToListAsync();
    }
 
} 