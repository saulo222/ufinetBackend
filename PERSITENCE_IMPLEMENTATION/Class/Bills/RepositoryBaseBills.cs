using DOMAIN_AGGREGATES.GetTask.Commands;
using DOMAIN_CORE.Class;
using PERSITENCE_CORE.Aggregates;
using PERSITENCE_REPOSITORY.Class.Repository;

namespace PERSITENCE_IMPLEMENTATION.Class.Task
{
    /// <summary>
    /// Created by: Saul Cruz
    /// Date Created:20/07/2022
    /// </summary>
    public class BillsRepository : RepositoryBaseUnit<Bills>, IBills
    {
        public BillsRepository(IContextWorkUnit contextWorkUnit) : base(contextWorkUnit) { }


    }
}
