using BankingCreditSystem.Core.Entities.Concrete;

namespace BankingCreditSystem.Core.Security.JWT
{
	public interface ITokenHelper
	{
		AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);
	}
}
