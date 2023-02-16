
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using APLICATION_AGGREGATES.Aggregates.Commands;
using DOMAIN_CORE.Class;
using APLICATION_CORE.Class;
using APLICATION_AGGREGATES.Aggregates.Queries;
using INGETEC_INFRA_TOOLS_AGG;
using INGETEC_INFRA_TOOLS_CORE;

namespace APP_TEST_WEELO_API_ADD_PROPERTY
{
    public class BillsController : ControllerBase
    {
        private readonly IBillsServices _billsServices;
        private readonly IGetBillsServices _getBillsServices;
        private readonly ILog _log;
        private readonly IActionContextAccessor _accessor;
        public BillsController(IBillsServices billsServices,
                                        IGetBillsServices getBillsServices,
                                        ILog log,
                                        IActionContextAccessor accessor)
        {
            _billsServices = billsServices;
            _getBillsServices = getBillsServices;
            _log = log;
            _accessor = accessor;
        }

        /// <summary>
        /// Created By :Saul Cruz
        /// Date Created:12/02/2023
        /// Inserta una nueva  factura en el modelo billd
        /// </summary>
        /// <param name="billsTDO"></param>
        /// <returns>Task</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type  = typeof(Boolean))]
        [ProducesResponseType(404)]
        [Route("api/addBills")]
        public async Task<IActionResult> Invoque([FromBody] BillsDTO billsTDO)
        {
            IActionResult result;
             try
            {

                result = Ok(_billsServices.Add(billsTDO));
                return result;
            }
            catch (System.Exception ex)
            {
                InsertLogTrace(ex.Message + "-" + ex.StackTrace, string.Empty);
                return BadRequest();
            }

        }

        /// <summary>
        /// Created By :Saul Cruz
        /// Date Created:20/07/2022
        /// Elimina una tarea existente por billID en el modelo Billd
        /// </summary>
        /// <param name="billID"></param>
        // <returns></returns>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(Boolean))]
        [ProducesResponseType(404)]
        [Route("api/deleteBilld/{billID}")]
        public async Task<IActionResult> delete(Guid billID)
        {
            IActionResult result;
            try
            {
                BillsDTO billsDTO = new BillsDTO();
                billsDTO.BillID = billID;

                result = Ok(_billsServices.Delete(billsDTO));
                return result;
            }
            catch (System.Exception ex)
            {
                InsertLogTrace(ex.Message + "-" + ex.StackTrace, string.Empty);
                return BadRequest();
            }

        }
        /// <summary>
        /// Created By :Saul Cruz
        /// Date Created:12/02/2023
        /// </summary>
        /// <remarks>
        /// Obtiene una lista de Facturas  existentes  en el modelo Bills.
        /// </remarks>
        /// <param name="customerID"></param>
        /// <returns>dynamic</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetBills>))]
        [ProducesResponseType(404)]
        [Route("api/getbill/{customerID}")]
        public async Task<IActionResult> Invoque(Guid customerID)
        {
            IActionResult result;
            try
            {

                result = Ok(_getBillsServices.GetBill(customerID));
                return result;
            }
            catch (System.Exception ex)
            {
                InsertLogTrace(ex.Message + "-" + ex.StackTrace, string.Empty);
                return BadRequest();
            }

        }

        private void InsertLogTrace(string contentTrace, string dataSource)
        {
            StackTrace stackTrace = new StackTrace();

            _log.InsertTraceLog(
                 new INGETEC_INFRA_TOOLS_CORE.Log
                 {
                     TypeLog = TypeLog.ERROR,
                     NameMethod = stackTrace.GetFrame(1).GetMethod().Name,
                     NameAPI = stackTrace.GetFrame(1).GetFileName(),
                     DateCreated = System.DateTime.Now,
                     LogID = System.Guid.NewGuid(),
                     Content = contentTrace,
                     DataSource = dataSource,
                     IPSource = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString()



                 });

        }


    }
}