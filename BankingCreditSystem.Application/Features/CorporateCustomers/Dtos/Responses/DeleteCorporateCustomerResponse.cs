namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;

public class DeleteCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string Message { get; set; } = default!;
} 