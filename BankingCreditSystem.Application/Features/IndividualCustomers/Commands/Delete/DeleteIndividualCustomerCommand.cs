using BankingCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using MediatR;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Delete;

public class DeleteIndividualCustomerCommand : IRequest<DeleteIndividualCustomerResponse>
{
    public Guid Id { get; set; }
}

public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, DeleteIndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

    public DeleteIndividualCustomerCommandHandler(
        IIndividualCustomerRepository individualCustomerRepository,
        IndividualCustomerBusinessRules individualCustomerBusinessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _individualCustomerBusinessRules = individualCustomerBusinessRules;
    }

    public async Task<DeleteIndividualCustomerResponse> Handle(DeleteIndividualCustomerCommand command, CancellationToken cancellationToken)
    {
        await _individualCustomerBusinessRules.CustomerShouldExistWhenRequested(command.Id);
        
        var individualCustomer = await _individualCustomerRepository.GetAsync(c => c.Id == command.Id);
        individualCustomer.IsActive = false;
        await _individualCustomerRepository.DeleteAsync(individualCustomer);
        
        return new DeleteIndividualCustomerResponse { Id = command.Id , Message = IndividualCustomerMessages.CustomerDeleted};
    }
} 