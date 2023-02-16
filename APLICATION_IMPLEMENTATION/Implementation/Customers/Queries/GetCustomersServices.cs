using APLICATION_AGGREGATES.Aggregates.Commands;
using APLICATION_AGGREGATES.Aggregates.Queries;
using APLICATION_CORE.Class;
using APLICATION_CORE.Mappers;
using AutoMapper;
using DOMAIN_AGGREGATES.GetTask.Commands;
using DOMAIN_CORE.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION_IMPLEMENTATION.Implementation.Customers.Queries
{
    /// <summary>
    /// Created By :Saul Cruz
    /// Date Created:13/02/2023
    /// Service that contains the operations that a property implements.
    /// </summary>
    public class GetCustomersServices : IGetCustomersServices
    {

        private ICustomers _customers;
        public GetCustomersServices(ICustomers customers

                               )
        {
            _customers = customers;

        }

        public List<DOMAIN_CORE.Class.Customers> Getall()
        {
            return _customers.GetAll();
        }


        public void Dispose()
        {
            _customers.Dispose();
        }


    }
}
