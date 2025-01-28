using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messaging.Events;

public record IntegrationEvent
{
    public Guid EventId => Guid.NewGuid();
    public DateTime OcuuredOn => DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName;
}
