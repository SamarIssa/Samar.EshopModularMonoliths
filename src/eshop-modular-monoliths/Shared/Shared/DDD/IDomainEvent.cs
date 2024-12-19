namespace Shared.DDD;

public interface IDomainEvent
{
    Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.UtcNow;
    public string EventType => GetType().AssemblyQualifiedName!;
}
