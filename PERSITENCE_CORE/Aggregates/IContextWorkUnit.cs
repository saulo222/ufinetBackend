using DOMAIN_AGGREGATES.Base;
using Microsoft.EntityFrameworkCore;

namespace PERSITENCE_CORE.Aggregates
{
    public interface IContextWorkUnit : IWorkUnit, IDisposable
    {
        DbSet<Entity> Set<Entity>() where Entity : class;
        void SetDetached<Entity>(Entity item) where Entity : class;


    }
}
