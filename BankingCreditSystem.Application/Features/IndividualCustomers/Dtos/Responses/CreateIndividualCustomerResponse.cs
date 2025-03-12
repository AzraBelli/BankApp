namespace BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

public class CreateIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
	public string Email { get; set; } = default!;
	public string PhoneNumber { get; set; } = default!;
	public DateTime CreatedDate { get; set; }
    public string Message { get; set; } = default!;
}