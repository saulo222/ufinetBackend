
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
//using INFRA_TOOLS_AGGREGATES.Class.Log;
//using INFRA_TOOLS_CORE.Class.Log;
using APLICATION_AGGREGATES.Aggregates.Commands;
using DOMAIN_CORE.Class;
using APLICATION_CORE.Class;
using APLICATION_AGGREGATES.Aggregates.Queries;

namespace APP_TEST_WEELO_API_ADD_PROPERTY
{
    public class CommandsTaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;
        private readonly IGetTaskServices _gettaskServices;
       // private readonly ILog _log;
        private readonly IActionContextAccessor _accessor;
        public CommandsTaskController(ITaskServices taskServices, IGetTaskServices gettaskServices,
                                //        ILog log,
                                        IActionContextAccessor accessor)
        {
            _taskServices = taskServices;
            _gettaskServices = gettaskServices;
         //   _log = log;
            _accessor = accessor;
        }

        /// <summary>
        /// Created By :Saul Cruz
        /// Date Created:20/07/2022
        /// Inserta una tarea nueva en el modelo TASK
        /// </summary>
        /// <param name="taskTDO"></param>
        /// <returns>Task</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type  = typeof(Boolean))]
        [ProducesResponseType(404)]
        [Route("api/addtask")]
        public async Task<IActionResult> Invoque([FromBody] TaskDTO taskTDO)
        {
            IActionResult result;
             try
            {

                result = Ok(_taskServices.Add(taskTDO));
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
        /// Edita una tarea existente en el modelo TASK
        /// </summary>
        /// <param name="taskTDO"></param>
        /// <returns>Task<IActionResult></returns>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Boolean))]
        [ProducesResponseType(404)]
        [Route("api/updatetask")]
        public async Task<IActionResult> update([FromBody] TaskDTO taskTDO)
        {
            IActionResult result;
            try
            {

                result = Ok(_taskServices.Update(taskTDO));
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
        /// Elimina una tarea existente por idTask en el modelo TASK
        /// </summary>
        /// <param name="idTask"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(Boolean))]
        [ProducesResponseType(404)]
        [Route("api/deletetask/{idTask}")]
        public async Task<IActionResult> delete(long idTask)
        {
            IActionResult result;
            try
            {
                TaskDTO taskDTO = new TaskDTO();
                taskDTO.idTask = idTask;

                result = Ok(_taskServices.Delete(taskDTO));
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
        /// </summary>
        /// <remarks>
        /// Obtiene una lista de tareas existentes  en el modelo TASK.
        /// </remarks>
        /// <param name="idTask"></param>
        /// <returns>dynamic</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<dynamic>))]
        [ProducesResponseType(404)]
        [Route("api/gettask")]
        public async Task<IActionResult> Invoque()
        {
            IActionResult result;
            try
            {

                result = Ok(_gettaskServices.GetTask());
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

            //_log.InsertTraceLog(
            //     new Logs
            //     {
            //         TypeLog = TypeLog.ERROR,
            //         NameMethod = stackTrace.GetFrame(1).GetMethod().Name,
            //         NameAPI = stackTrace.GetFrame(1).GetFileName(),
            //         DateCreated = System.DateTime.Now,
            //         LogID = System.Guid.NewGuid(),
            //         Content = contentTrace,
            //         DataSource = dataSource,
            //         IPSource = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString()



            //     });

        }


    }
}