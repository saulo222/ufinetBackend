using DOMAIN_AGGREGATES.Base;
using DOMAIN_CORE.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN_AGGREGATES.GetTask.Commands
{
    /// <summary>
    /// Created By :Saul Cruz
    /// Date Created:13/02/2023
    /// Contains operations implemented by Customers
    /// </summary>
    public interface ICustomers : IRepositoryBase<Customers>, IDisposable
    {

    }
}
