using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Update;

public class UpdateCorporateCustomerCommand : IRequest<UpdateCorporateCustomerResponse>
{
    public UpdateCorporateCustomerRequest Request { get; set; }
}

public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, UpdateCorporateCustomerResponse>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly IMapper _mapper;
    private readonly CorporateCustomerBusinessRules _businessRules;

    public UpdateCorporateCustomerCommandHandler(
        ICorporateCustomerRepository corporateCustomerRepository,
        IMapper mapper,
        CorporateCustomerBusinessRules businessRules)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<UpdateCorporateCustomerResponse> Handle(UpdateCorporateCustomerCommand command, CancellationToken cancellationToken)
    {
        await _businessRules.CustomerShouldExistWhenRequested(command.Request.Id);
        
        var corporateCustomer = await _corporateCustomerRepository.GetAsync(c => c.Id == command.Request.Id);
        _mapper.Map(command.Request, corporateCustomer);      
        
        var updatedCustomer = await _corporateCustomerRepository.UpdateAsync(corporateCustomer);
        var response = _mapper.Map<UpdateCorporateCustomerResponse>(updatedCustomer);
        response.Message = CorporateCustomerMessages.CustomerUpdated;
        return response;
    }
} 