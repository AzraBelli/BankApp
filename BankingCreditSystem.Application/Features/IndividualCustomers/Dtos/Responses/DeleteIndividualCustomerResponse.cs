namespace BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

public class DeleteIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string Message { get; set; } = default!;
}