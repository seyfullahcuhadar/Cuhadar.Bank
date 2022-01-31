using MediatR;
using System;
namespace Cuhadar.Bank.Domain.SeedWork
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}