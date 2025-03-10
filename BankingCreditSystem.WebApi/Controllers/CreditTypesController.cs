using BankingCreditSystem.Application.Features.CreditApplications.Commands.Create;
using BankingCreditSystem.Application.Features.CreditTypes.Commands.Create;
using BankingCreditSystem.Application.Features.CreditTypes.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace BankingCreditSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditTypesController : BaseController
{
	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateCreditTypeCommand createCreditApplicationCommand)
	{
		var result = await Mediator.Send(createCreditApplicationCommand);
		return Created("", result);
	}

	[HttpGet]
	public async Task<IActionResult> GetList([FromQuery] GetListCreditTypeQuery getListCreditTypeQuery)
	{
		var result = await Mediator.Send(getListCreditTypeQuery);
		return Ok(result);
	}
}