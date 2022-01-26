using System;
using MediatR;

namespace Cuhadar.Bank.Domain.SeedWork
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}