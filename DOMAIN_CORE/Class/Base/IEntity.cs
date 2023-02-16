using DOMAIN_CORE.Class.Base.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN_CORE.Class.Base
{
    public interface IEntity
    {
        IProducerConsumerCollection<IDomainEvent> DomainEvents { get; }
    }
}
