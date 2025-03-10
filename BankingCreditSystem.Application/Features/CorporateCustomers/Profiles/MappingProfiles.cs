using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;


namespace BankingCreditSystem.Application.Features.CorporateCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CorporateCustomer, CorporateCustomerResponse>();
        CreateMap<CorporateCustomer, CreateCorporateCustomerResponse>();
        CreateMap<CorporateCustomer, UpdateCorporateCustomerResponse>();

        CreateMap<CreateCorporateCustomerRequest, CorporateCustomer>();
        CreateMap<UpdateCorporateCustomerRequest, CorporateCustomer>();
        CreateMap<CreateCorporateCustomerCommand, CorporateCustomer>()
            .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Request.CompanyName))
            .ForMember(dest => dest.TaxNumber, opt => opt.MapFrom(src => src.Request.TaxNumber))
            .ForMember(dest => dest.TaxOffice, opt => opt.MapFrom(src => src.Request.TaxOffice))
            .ForMember(dest => dest.CompanyRegistrationNumber, opt => opt.MapFrom(src => src.Request.CompanyRegistrationNumber))
            .ForMember(dest => dest.AuthorizedPersonName, opt => opt.MapFrom(src => src.Request.AuthorizedPersonName))
            .ForMember(dest => dest.CompanyFoundationDate, opt => opt.MapFrom(src => src.Request.CompanyFoundationDate))
            .ForMember(dest => dest.User.PhoneNumber, opt => opt.MapFrom(src => src.Request.PhoneNumber))
            .ForMember(dest => dest.User.Email, opt => opt.MapFrom(src => src.Request.Email))
            .ForMember(dest => dest.User.Address, opt => opt.MapFrom(src => src.Request.Address));

        CreateMap<Paginate<CorporateCustomer>, Paginate<CorporateCustomerResponse>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
    }
} 