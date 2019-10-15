using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessRules;
using Entities.Models;
using Entities.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Produces("application/json")]
    public class TaskWorkController : ControllerBase
    {
        private readonly TaskWorkBR taskWorkBR;
        public TaskWorkController(TaskWorkBR taskWorkBR)
        {
            this.taskWorkBR = taskWorkBR;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TaskWork>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                var taskWorksFind = this.taskWorkBR.GetAllTasks();
                if (taskWorksFind.IsListObjectNull() || taskWorksFind.IsEmptyListObject()) { return NoContent(); }

                return Ok(taskWorksFind);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error {ex.Message}" });
            }
        }

        [HttpGet("{id}", Name = "TaskWorkById")]
        [ProducesResponseType(typeof(TaskWork), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Get(Guid id)
        {
            try
            {
                var taskWorkFind = this.taskWorkBR.GetTaskById(id);
                if (taskWorkFind.IsEmptyObject() || taskWorkFind.IsObjectNull()) { return NoContent(); }

                return Ok(taskWorkFind);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error {ex.Message}" });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskWork), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody]TaskWork taskWorkNew)
        {
            if (taskWorkNew.IsObjectNull()) { return BadRequest(new { Message = "DeathDate object is null" }); }
            if (!ModelState.IsValid) { return BadRequest(new { Message = "Invalid model object" }); }
            try
            {
                this.taskWorkBR.CreateTask(taskWorkNew);
                if (taskWorkNew.IsEmptyObject()) { return BadRequest(new { Message = "Task Object is not Created" }); }

                return CreatedAtRoute("TaskWorkById", new { id = taskWorkNew.Id }, taskWorkNew);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TaskWork), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Put(Guid id, [FromBody]TaskWork taskWork)
        {
            try
            {
                if (id.Equals(Guid.Empty)) { return BadRequest(new { Message = "Id is Empty" }); }
                if (taskWork.IsObjectNull()) { return BadRequest(new { Message = "Task Object is Null" }); }
                if (!ModelState.IsValid) { return BadRequest(new { Message = "Invalid model object" }); }

                bool secuence = this.taskWorkBR.UdpdateTask(id, taskWork);

                if (!secuence) { return NotFound(); }

                return Ok(taskWork);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(405)]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty)) { return BadRequest(new { Message = "Id is Empty" }); }

                bool secuence = this.taskWorkBR.DeleteTask(id);

                if (!secuence) { return StatusCode(405, new { Message = "Not allowed to delete Task registry." }); }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }
    }
}