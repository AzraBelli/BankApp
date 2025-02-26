using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Base response mapping
        CreateMap<IndividualCustomer, IndividualCustomerResponse>();
        CreateMap<IndividualCustomer, CreateIndividualCustomerResponse>();
        CreateMap<IndividualCustomer, UpdateIndividualCustomerResponse>();

        CreateMap<CreateIndividualCustomerRequest, IndividualCustomer>();
        CreateMap<UpdateIndividualCustomerRequest, IndividualCustomer>();

    }
} 