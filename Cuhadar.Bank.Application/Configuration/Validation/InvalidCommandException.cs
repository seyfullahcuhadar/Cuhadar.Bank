using System;

namespace Cuhadar.Bank.Application.Configuration.Validation
{
    public class InvalidCommandException : Exception
    {
        public string Details { get; }
        public InvalidCommandException(string message, string details) : base(message)
        {
            Details = details;
        }
    }
}