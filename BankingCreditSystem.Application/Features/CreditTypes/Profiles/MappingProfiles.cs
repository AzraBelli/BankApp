
using AutoMapper;
namespace BankingCreditSystem.Application.Features.CreditTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        
       CreateMap<CreditType, CreditTypeResponse>();
       CreateMap<CreateCreditTypeRequest, CreditType>();


       CreateMap<Paginate<CreditType>, Paginate<CreditTypeResponse>>()
            .ForMember(dest=> dest.Items,opt=> opt.MapFrom(src=>src.Items));		

	}
} 