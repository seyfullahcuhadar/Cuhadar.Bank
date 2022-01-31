using Cuhadar.Bank.Application.Configuration.Validation;
using Cuhadar.Bank.Infrastructure.SeedWork;
using Microsoft.AspNetCore.Http;

namespace Cuhadar.Bank.API.SeedWork
{
    public class InfrastructureExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public InfrastructureExceptionProblemDetails(InfrastructureException exception)
        {
            Title = "An error occured";
            Status = StatusCodes.Status400BadRequest;
            Detail = exception.Message.ToString();
            Type = "https://somedomain/validation-error";
        }
    }
}