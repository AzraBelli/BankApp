using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface ICustomerRepository<T> : IAsyncRepository<T,Guid> where T :Customer
{
} 