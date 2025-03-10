using BankingCreditSystem.Core.Application.Authorization;
using MediatR;

namespace BankingCreditSystem.Application.Features.CreditApplications.Queries.GetLİst
{
	public class GetListCreditApplicationQuery:IRequest<Paginate<CreditApplicationResponse>>,ISecuredRequest
	{
		public string[] Roles => new[] { "Admin", "BankStaff" };
	}
}
