﻿using Cuhadar.Bank.Domain.SeedWork;
using Microsoft.AspNetCore.Http;

namespace Cuhadar.Bank.API.SeedWork
{
    public class BusinessRuleValidationExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
        {
            Title = "Business rule validation error";
            Status = StatusCodes.Status409Conflict;
            Detail = exception.Details;
            Type = "https://somedomain/business-rule-validation-error";
        }
    }
}