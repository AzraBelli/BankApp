using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Core.Security.Hashing;
using BankingCreditSystem.Domain.Entities;
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
            var applicationUser = new ApplicationUser {
                Email=command.Request.Email,
                PhoneNumber=command.Request.PhoneNumber,
                Address=command.Request.Address,
                Status=true          
            };
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(command.Request.Password, out passwordHash, out passwordSalt);
            applicationUser.PasswordHash = passwordHash;
            applicationUser.PasswordSalt = passwordSalt;



            var individualCustomer = new IndividualCustomer {
                FirstName=command.Request.FirstName,
                LastName=command.Request.LastName,
                NationalId=command.Request.NationalId,
                DateOfBirth=command.Request.DateOfBirth,
                MotherName=command.Request.MotherName,
                FatherName=command.Request.FatherName,
                User=applicationUser,
                IsActive=true            
            };


            var createdCustomer = await _individualCustomerRepository.AddAsync(individualCustomer);
            var response=_mapper.Map<CreateIndividualCustomerResponse>(createdCustomer);
            response.Message = IndividualCustomerMessages.CustomerCreated;
            return response;
        }
    }
} 