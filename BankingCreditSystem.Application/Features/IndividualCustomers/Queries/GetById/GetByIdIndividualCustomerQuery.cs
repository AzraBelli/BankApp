using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;

public class GetByIdIndividualCustomerQuery : IRequest<IndividualCustomerResponse>
{
    public Guid Id { get; set; } 

    public class GetByIdIndividualCustomerQueryHandler : IRequestHandler<GetByIdIndividualCustomerQuery, IndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public GetByIdIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<IndividualCustomerResponse> Handle(GetByIdIndividualCustomerQuery query, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExistWhenRequested(query.Id);
            var customer = await _individualCustomerRepository.GetAsync(c => c.Id == query.Id);             

            return _mapper.Map<IndividualCustomerResponse>(customer);
        }
    }
}