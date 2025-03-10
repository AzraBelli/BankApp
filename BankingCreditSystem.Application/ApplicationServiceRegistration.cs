using System.Reflection;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;

namespace BankingCreditSystem.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Business Rules
        services.AddScoped<IndividualCustomerBusinessRules>();
        services.AddScoped<CorporateCustomerBusinessRules>();
        // Diğer business rules'lar buraya eklenecek

        return services;
    }
} 