using BankingCreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules
{
    private readonly ICorporateCustomerRepository _repository;

    public CorporateCustomerBusinessRules(ICorporateCustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task CustomerShouldExistWhenRequested(Guid id)
    {
        var exists = await _repository.AnyAsync(c => c.Id == id);
        if (!exists)
            throw new BusinessException(CorporateCustomerMessages.CustomerNotFound);
    }

    public async Task TaxNumberCannotBeDuplicatedWhenInserted(string taxNumber)
    {
        var exists = await _repository.AnyAsync(c => c.TaxNumber == taxNumber);
        if (exists)
            throw new BusinessException(CorporateCustomerMessages.TaxNumberAlreadyExists);
    }
    
} 