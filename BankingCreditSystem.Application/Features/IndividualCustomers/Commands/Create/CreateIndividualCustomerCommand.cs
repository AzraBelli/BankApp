using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using MediatR;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerResponse>
{
    public CreateIndividualCustomerRequest Request { get; set; } = default!;

    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreateIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand command, CancellationToken cancellationToken)
        {
            await _businessRules.NationalIdCannotBeDuplicatedWhenInserted(command.Request.NationalId);

            var individualCustomer = _mapper.Map<IndividualCustomer>(command.Request);
            var createdCustomer = await _individualCustomerRepository.AddAsync(individualCustomer,cancellationToken);
            var response=_mapper.Map<CreateIndividualCustomerResponse>(createdCustomer);
            response.Message = IndividualCustomerMessages.CustomerCreated;
            return response;
        }
    }
} 