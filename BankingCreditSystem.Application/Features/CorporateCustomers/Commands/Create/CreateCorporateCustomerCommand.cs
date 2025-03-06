using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create;

public class CreateCorporateCustomerCommand : IRequest<CreateCorporateCustomerResponse>
{
    public CreateCorporateCustomerRequest Request { get; set; }
}

public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreateCorporateCustomerResponse>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly IMapper _mapper;
    private readonly CorporateCustomerBusinessRules _businessRules;

    public CreateCorporateCustomerCommandHandler(
        ICorporateCustomerRepository corporateCustomerRepository,
        IMapper mapper,
        CorporateCustomerBusinessRules businessRules)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<CreateCorporateCustomerResponse> Handle(CreateCorporateCustomerCommand command, CancellationToken cancellationToken)
    {
        await _businessRules.TaxNumberCannotBeDuplicatedWhenInserted(command.Request.CompanyRegistrationNumber);        
        var corporateCustomer = _mapper.Map<CorporateCustomer>(command.Request);        
        var createdCustomer = await _corporateCustomerRepository.AddAsync(corporateCustomer,cancellationToken);       
        var response = _mapper.Map<CreateCorporateCustomerResponse>(createdCustomer);
        response.Message = CorporateCustomerMessages.CustomerCreated;
        return response;
    }
} 