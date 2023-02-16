using DOMAIN_CORE.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN_AGGREGATES.Users
{
    /// <summary>
    /// Created By : Saul Cruz
    /// Date Created : 13/02/2023
    /// Contains the query operations implemented by Task
    /// </summary>
    public interface IGetBills : IDisposable
    {
        IEnumerable<GetBills> GetBill(Guid customerID);
       
    }
}
