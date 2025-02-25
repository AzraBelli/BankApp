using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Persistence.Context;

namespace BankingCreditSystem.Persistence.Repositories;

public class CorporateCustomerRepository : CustomerRepository<CorporateCustomer>, ICorporateCustomerRepository
{
    public CorporateCustomerRepository(BaseDbContext context) : base(context)
    {
    }
} 