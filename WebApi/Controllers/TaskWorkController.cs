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
        public IActionResult Get(int? year, int? month)
        {
            try
            {
                var deathDatesFind = this.taskWorkBR.GetAllDates(year, month);
                if (deathDatesFind.IsListObjectNull() || deathDatesFind.IsEmptyListObject()) { return NoContent(); }

                return Ok(deathDatesFind);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error {ex.Message}" });
            }
        }

        [HttpGet("{id}", Name = "DeathDateById")]
        [ProducesResponseType(typeof(TaskWork), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Get(Guid id)
        {
            try
            {
                var deathDateFind = this.taskWorkBR.GetDateById(id);
                if (deathDateFind.IsEmptyObject() || deathDateFind.IsObjectNull()) { return NoContent(); }

                return Ok(deathDateFind);
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
        public IActionResult Post([FromBody]TaskWork deathDateNew)
        {
            if (deathDateNew.IsObjectNull()) { return BadRequest(new { Message = "DeathDate object is null" }); }
            if (!ModelState.IsValid) { return BadRequest(new { Message = "Invalid model object" }); }
            try
            {
                var secuence = this.taskWorkBR.CreateDate(deathDateNew);
                if (!secuence) { return BadRequest(new { Message = "DeathDate Object is not Created" }); }
                if (deathDateNew.IsEmptyObject()) { return BadRequest(new { Message = "DeathDate Object is not Created" }); }

                return CreatedAtRoute("DeathDateById", new { id = deathDateNew.Id }, deathDateNew);
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
        public IActionResult Put(Guid id, [FromBody]TaskWork deathDate)
        {
            try
            {
                if (id.Equals(Guid.Empty)) { return BadRequest(new { Message = "Id is Empty" }); }
                if (deathDate.IsObjectNull()) { return BadRequest(new { Message = "DeathDate Object is Null" }); }
                if (!ModelState.IsValid) { return BadRequest(new { Message = "Invalid model object" }); }

                bool secuence = this.taskWorkBR.UdpdateDate(id, deathDate);

                if (!secuence) { return NotFound(); }

                return Ok(deathDate);
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

                bool secuence = this.taskWorkBR.DeleteDate(id);

                if (!secuence) { return StatusCode(405, new { Message = "Not allowed to delete Death Date registry." }); }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }
    }
}