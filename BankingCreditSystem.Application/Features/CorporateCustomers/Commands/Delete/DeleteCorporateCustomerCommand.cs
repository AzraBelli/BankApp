using BankingCreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Delete;

public class DeleteCorporateCustomerCommand : IRequest<DeleteCorporateCustomerResponse>
{
    public Guid Id { get; set; }
}

public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, DeleteCorporateCustomerResponse>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly CorporateCustomerBusinessRules _businessRules;

    public DeleteCorporateCustomerCommandHandler(
        ICorporateCustomerRepository corporateCustomerRepository,
        CorporateCustomerBusinessRules businessRules)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _businessRules = businessRules;
    }

    public async Task<DeleteCorporateCustomerResponse> Handle(DeleteCorporateCustomerCommand command, CancellationToken cancellationToken)
    {
        await _businessRules.CustomerShouldExistWhenRequested(command.Id);
        
        var corporateCustomer = await _corporateCustomerRepository.GetAsync(c => c.Id == command.Id);
        corporateCustomer.IsActive = false;
        await _corporateCustomerRepository.DeleteAsync(corporateCustomer);
        
        return new DeleteCorporateCustomerResponse { Id = command.Id, Message = CorporateCustomerMessages.CustomerDeleted };
    }
} 