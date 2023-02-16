
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using APLICATION_AGGREGATES.Aggregates.Queries;
using INFRA_TOOLS_AGGREGATES.Class.Log;
using INFRA_TOOLS_CORE.Class.Log;

namespace APP_TEST_WEELO_API_ADD_PROPERTY
{
    public class GetTaskController : ControllerBase
    {
        private readonly IGetTaskServices _taskServices;
        private readonly ILog _log;
        private readonly IActionContextAccessor _accessor;
        public GetTaskController(IGetTaskServices taskServices,
                                        ILog log,
                                        IActionContextAccessor accessor)
        {
            _taskServices = taskServices;
            _log = log;
            _accessor = accessor;
        }

       // [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<dynamic>))]
        [ProducesResponseType(404)]
        [Route("api/gettask")]
        public async Task<IActionResult> Invoque()
        {
            IActionResult result;
             try
            {
                   
                result = Ok(_taskServices.GetTask());
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
                 new Logs
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