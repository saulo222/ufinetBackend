using DOMAIN_CORE.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION_AGGREGATES.Aggregates.Queries
{
    /// <summary>
    /// Created By :Saul Cruz
    /// Date Created:13/02/2023
    /// Contains the query operations implemented by Customers
    /// </summary>
    public interface IGetCustomersServices : IDisposable
    {
        public List<Customers> Getall();

    }

}
