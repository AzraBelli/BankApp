using System.Security.Claims;

namespace BankingCreditSystem.Core.Security.Extensions
{
	public static class ClaimPrincipalExtensions
	{
		public static string[] ClaimRoles(this ClaimsPrincipal principal)
		{
			return principal?.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToArray();
		}
	}
}
