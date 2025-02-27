using BankingCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerRepository _repository;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task CustomerShouldExistWhenRequested(Guid id)
    {
        var exists = await _repository.AnyAsync(c => c.Id == id);
        if (!exists)
            throw new BusinessException(IndividualCustomerMessages.CustomerNotFound);
    }
    public async Task NationalIdCannotBeDuplicatedWhenInserted(string nationalId)
    {
        var exists = await _repository.AnyAsync(c => c.NationalId == nationalId);
        if (exists)
            throw new BusinessException(IndividualCustomerMessages.NationalIdAlreadyExists);
    }
} 