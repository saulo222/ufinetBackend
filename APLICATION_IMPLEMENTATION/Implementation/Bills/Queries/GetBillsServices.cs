using APLICATION_AGGREGATES.Aggregates.Commands;
using APLICATION_AGGREGATES.Aggregates.Queries;
using APLICATION_CORE.Class;
using APLICATION_CORE.Mappers;
using AutoMapper;
using DOMAIN_AGGREGATES.GetTask.Commands;
using DOMAIN_AGGREGATES.Users;
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
    public class GetBillsServices : IGetBillsServices
    {

        private IGetBills _getBills;
        public GetBillsServices(IGetBills getBills

                               )
        {
            _getBills = getBills;

        }

        public IEnumerable<GetBills> GetBill(Guid customerID)
        {
            IEnumerable<GetBills> result= _getBills.GetBill(customerID);
            return result;
        }


        public void Dispose()
        {
            _getBills.Dispose();
        }


    }
}
