using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception)
    {
        if (exception is BusinessException businessException)
        {
            return HandleException(businessException);
        }
        if (exception is ValidationException validationException)
        {
            return HandleException(validationException);
        }
        if (exception is AuthorizationException authorizationException)
        {
            return HandleException(authorizationException);
        }
        return HandleException(exception);
    }

    protected abstract Task HandleException(BusinessException businessexception);
    protected abstract Task HandleException(ValidationException validationexception);
    protected abstract Task HandleException(AuthorizationException authorizationexception);
    protected abstract Task HandleException(Exception exception);
} 