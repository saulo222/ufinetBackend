
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
    public class CustomersController : ControllerBase
    {
        private readonly IGetCustomersServices _getCustomersServices;
      //  private readonly IGetTaskServices _gettaskServices;
        private readonly ILog _log;
        private readonly IActionContextAccessor _accessor;
        public CustomersController(IGetCustomersServices getCustomersServices,
                                        ILog log,
                                        IActionContextAccessor accessor)
        {
            _getCustomersServices = getCustomersServices;
            _log = log;
            _accessor = accessor;
        }

        /// <summary>
        /// Created By :Saul Cruz
        /// Date Created:12/02/2023
        /// Inserta una nueva  factura en el modelo bills
        /// </summary>
        /// <returns>Task</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<DOMAIN_CORE.Class.Customers>))]
        [ProducesResponseType(404)]
        [Route("api/getCustomers")]
        public async Task<IActionResult> Invoque()
        {
            IActionResult result;
            try
            {
                result = Ok(_getCustomersServices.Getall());
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