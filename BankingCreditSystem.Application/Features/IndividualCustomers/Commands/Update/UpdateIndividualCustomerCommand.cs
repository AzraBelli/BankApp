using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using MediatR;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Update;

public class UpdateIndividualCustomerCommand : IRequest<UpdateIndividualCustomerResponse>
{    
    public UpdateIndividualCustomerRequest Request { get; set; }
}

public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdateIndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;
    private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

    public UpdateIndividualCustomerCommandHandler(
        IIndividualCustomerRepository individualCustomerRepository,
        IMapper mapper,
        IndividualCustomerBusinessRules individualCustomerBusinessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
        _individualCustomerBusinessRules = individualCustomerBusinessRules;
    }

    public async Task<UpdateIndividualCustomerResponse> Handle(UpdateIndividualCustomerCommand command, CancellationToken cancellationToken)
    {
        await _individualCustomerBusinessRules.CustomerShouldExistWhenRequested(command.Request.Id);
        
        var individualCustomer = await _individualCustomerRepository.GetAsync(c => c.Id == command.Request.Id);
        _mapper.Map(command.Request, individualCustomer);
        
        var updatedCustomer = await _individualCustomerRepository.UpdateAsync(individualCustomer);
        var response = _mapper.Map<UpdateIndividualCustomerResponse>(updatedCustomer);
        response.Message = IndividualCustomerMessages.CustomerUpdated;
        return response;
    }
} 