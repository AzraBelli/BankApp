using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface ICreditTypeRepository : IAsyncRepository<CreditType, Guid>
{
    Task<IList<CreditType>> GetByCustomerTypesAsync(CustomerType customerType);
    Task<IList<CreditType>> GetSubCreditTypesAsync(Guid parentCreditTypeId);
} 