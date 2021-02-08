using System.Collections.Generic;
using System.Linq;
using RestFul.Data;
using RestFul.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System;

/*
 SEE TUTORIAL:
on controllers
>>>>>> https://code-maze.com/net-core-web-development-part6/
& 
on REST with a ClientApp that CRUDs
>>>>>> https://www.codaffection.com/asp-net-core-article/angular-crud-with-asp-net-core-web-api/
 */

namespace RestFul.Controllers {

  [ApiController]
  [Route(Entrypoint)]
  public class CodingEventsController : ControllerBase {
    public const string Entrypoint = "/api/events";

    private readonly CodingEventsDbContext _dbContext;

    public CodingEventsController(CodingEventsDbContext dbContext) {
      _dbContext = dbContext;
    }



        /*______________CREATE (ONE)______________*/
        [HttpPost]
        [SwaggerOperation(OperationId = "RegisterCodingEvent", Summary = "Create a new Coding Event")]
        [SwaggerResponse(201, "Returns new Coding Event data", Type = typeof(CodingEvent))]
        [SwaggerResponse(400, "Invalid or missing Coding Event data", Type = null)]
        public ActionResult RegisterCodingEvent([FromBody] NewCodingEventDto newCodingEventDto)
        {
            var codingEventEntry = _dbContext.CodingEvents.Add(new CodingEvent());
            codingEventEntry.CurrentValues.SetValues(newCodingEventDto);
            _dbContext.SaveChanges();

            var newCodingEvent = codingEventEntry.Entity;

            return CreatedAtAction(
                nameof(GetCodingEvent),
                new { codingEventId = newCodingEvent.Id },
                newCodingEvent
            );
        }


       /*______________READ (ALL)______________*/
        [HttpGet]
        [SwaggerOperation(
          OperationId = "GetCodingEvents",
          Summary = "Retrieve all Coding Events",
          Description = "Publicly available"
        )]
        [SwaggerResponse(200, "List of public Coding Event data", Type = typeof(List<CodingEvent>))]
        public ActionResult GetCodingEvents() => Ok(_dbContext.CodingEvents.ToList());



        /*______________READ (ONE)______________*/
        [HttpGet]
        [Route("{codingEventId}")]
        [SwaggerOperation(OperationId = "GetCodingEvent", Summary = "Retrieve Coding Event data")]
        [SwaggerResponse(200, "Complete Coding Event data", Type = typeof(CodingEvent))]
        [SwaggerResponse(404, "Coding Event not found", Type = null)]
        public ActionResult GetCodingEvent([FromRoute] long codingEventId) {
          var codingEvent = _dbContext.CodingEvents.Find(codingEventId);
          if (codingEvent == null) return NotFound();

          return Ok(codingEvent);
            }    


        /*______________UPDATE (ONE)______________*/
        [HttpPut]
        [Route("{codingEventId}")]
        public ActionResult EditCodingEvent([FromRoute] long codingEventId, [FromBody] UpdateCodingEventDto newCodingEventDto)
        {

            try
            {
                if (newCodingEventDto == null)
                {
                    /* TODO (POST-STUDIO), 
                     * for best practices one should make a _logger...*/
                    return BadRequest("Coding Event is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var oldCodingEvent = _dbContext.CodingEvents.Find(codingEventId);
                if (oldCodingEvent == null)
                {
                    return NotFound();
                }

                /* TODO (POST-STUDIO): 
                 * make a _mapper and requisite interfaces as go-between DTO's & DATABASE TABLES
                | >>> updating these fields manually is far from ideal...
                | >>> but hey... 'make it work, then make it better'*/

                oldCodingEvent.Date = newCodingEventDto.Date;
                oldCodingEvent.Title = newCodingEventDto.Title;
                oldCodingEvent.Description = newCodingEventDto.Description;

                _dbContext.SaveChanges();

                return NoContent();
            }

            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");

            }
        }


        /*______________DELETE (ONE)______________*/
        [HttpDelete]
        [Route("{codingEventId}")]
        [SwaggerOperation(
          OperationId = "CancelCodingEvent",
          Summary = "Cancel (delete) a Coding Event"
        )]
        [ProducesResponseType(204)] // suppress default swagger 200 response code
        [SwaggerResponse(204, "No content success", Type = null)]
        public ActionResult CancelCodingEvent([FromRoute] long codingEventId)
        {
            _dbContext.CodingEvents.Remove(new CodingEvent { Id = codingEventId });

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                // row did not exist
                return NotFound();
            }

            return NoContent();
        }


    }
}
