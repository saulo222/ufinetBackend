using DOMAIN_AGGREGATES.GetTask.Commands;
using DOMAIN_CORE.Class;
using PERSITENCE_CORE.Aggregates;
using PERSITENCE_REPOSITORY.Class.Repository;

namespace PERSITENCE_IMPLEMENTATION.Class.Task
{
    /// <summary>
    /// Created By :Saul Cruz
    /// Date Created:13/02/2023
    /// </summary>
    public class CustomersRepository : RepositoryBaseUnit<Customers>, ICustomers
    {
        public CustomersRepository(IContextWorkUnit contextWorkUnit) : base(contextWorkUnit) { }


    }
}
