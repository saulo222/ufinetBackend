using APLICATION_CORE.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION_AGGREGATES.Aggregates.Commands
{
    /// <summary>
    /// Created By :Saul Cruz
    /// Date Created:12/02/2023
    /// Contains definitions  that a property implement
    /// </summary>
    public interface IBillsServices : IDisposable
    {
        Task<bool> Add(BillsDTO billsDTO);
        bool Delete(BillsDTO billsDTO);

    }
}
