using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN_AGGREGATES.Base
{
    /// <summary>
    /// Created by: Saul Cruz
    /// Date Created:20/07/2022
    /// Base Operations of the Entities 
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IRepositoryBase<Entity> : IDisposable
    {

        IWorkUnit WorkUnit { get; }
        Entity GetByID(Guid id);
        Task<bool> AddRange(List<Entity> entities);
        Task<bool> Add(Entity entity);
        bool Update(Entity entity);
        bool Delete(Entity entity);
        bool UpdateRange(Entity entity);

        bool Attach(Entity entity);
        void SetDetached(Entity entity);
        List<Entity> GetAll();

    }
}
