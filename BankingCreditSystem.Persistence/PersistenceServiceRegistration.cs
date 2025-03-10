using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Persistence.Context;
using BankingCreditSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingCreditSystem.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Repositories
        services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
        services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
        services.AddScoped<ICreditTypeRepository, CreditTypeRepository>();
        services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();
        // Diğer repository'ler buraya eklenecek

        return services;
    }
} 