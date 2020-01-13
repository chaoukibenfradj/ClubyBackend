using System.Collections.Generic;
using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clubyApi.Controllers
{
    [Authorize]

    [Route("api/v1/events")]
    [ApiController]

    public class EventController :ControllerBase
    {
        private readonly IEventService _service;
        public EventController(IEventService service){
            _service=service;

        }

        [AllowAnonymous]
        [Authorize(Roles=Role.Club)]
        [HttpPost("event")]
        public ActionResult<Event> CreateEvent([FromBody]Event e) 
        {
            return Ok(_service.CreateEvent(e));
        }
        [AllowAnonymous]
        [HttpGet("")]
        public ActionResult<List<Event>> ShowAllEvents() 
        {
            return Ok(_service.ShowAllEvents());
        }
        [AllowAnonymous]

        //[HttpGet("{club}")]
        [Route("ByClub/{club}")]
        [HttpGet]
        public ActionResult<List<Event>> ShowEventByClub(string club) 
        {
            return Ok(_service.FindEventByClub(club));
        }
        [AllowAnonymous]

        //[HttpGet("{date}")]
        [Route("ByDate/{date}")]
        [HttpGet]
        public ActionResult<List<Event>> ShowEventByDate(string date) 
        {
            return Ok(_service.FindEventByDate(date));
        }
        [AllowAnonymous]

        //[HttpGet("{institute}")]
        [Route("ByInstitute/{institute}")]
        [HttpGet]
        public ActionResult<List<Event>> ShowEventByInstitute(string institute) 
        {
            return Ok(_service.FindEventByInstitute(institute));
        }
        [AllowAnonymous]

        [Route("ByDomain/{domain}")]
        [HttpGet]
        // [HttpGet("ByDomain/{domain}")]
        public ActionResult<List<Event>> ShowEventByDomain(string domain) 
        {
            return Ok(_service.FindEventByDomain(domain));
        }

        [AllowAnonymous]

        [HttpDelete("{id}")]
        public ActionResult<Event> DeleteEvent(string id){
            Event res=_service.DeleteEvent(id);
            if(res==null){
                return BadRequest(new {message="Could not delete Event"});
            }
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Event> FindEventById(string id) 
        {   Event e =_service.FindEventById(id);
            if(e==null){
                 
                return BadRequest(new {message="Could not find this Event ID"});

            }
            return Ok(e);
        }
 

       // [Authorize(Roles=Role.Student)]
        [AllowAnonymous]
        [HttpPost("participate")]
        public ActionResult<Event> AddUserParticipation([FromBody]PartModel p) 
        {
            int x =_service.AddUserParticipation(p.eventId,p.userId);
            switch (x) { 
              
                case 1: 
                            return BadRequest(new {message="Could not find this Event ID"});
                            break;   
                case 2: 
                            return BadRequest(new {message="Sorry all the place are taken"});
                            break; 
                case 3: 
                            return BadRequest(new {message="You already participate in this event"});
                            break; 
                case 0: 
                            return Ok("Participation added successfully");
                            break; 
                default: 
                            return BadRequest(new {message="Something went wrong"});
                            break; 
            } 
        } 

        [Authorize(Roles=Role.Student)]
        [AllowAnonymous]
        [HttpDelete("participate")]
        public ActionResult<Event> DeleteUserParticipation([FromBody] PartModel p) 
        {


            int x =_service.DeleteUserParticipation(p.eventId,p.userId);
            switch (x) { 
              
                case 1: 
                            return BadRequest(new {message="Could not find this Event ID"});
                            break;   
                case 2: 
                            return BadRequest(new {message="Sorry this user do not participate in this event"});
                            break; 
                case 0: 
                            return Ok("Delete participation done successfully");
                            break; 
                default: 
                            return BadRequest(new {message="Something went wrong"});
                            break; 
            } 
        } 


        // [Authorize(Roles=Role.Student)]
        [AllowAnonymous]
        [Route("participationUser/{id}")]
        [HttpGet]
        // [HttpGet("ByDomain/{domain}")]
        public ActionResult<List<Event>> FindEventByUserParticipation(string id) 
        {
            return Ok(_service.FindEventByUserParticipation(id));
        }
        [AllowAnonymous]
        //[Authorize(Roles=Role.Club)]
        [Route("participationEvent/{id}")]
        [HttpGet]
        public ActionResult<List<Participate>> ListEventPart(string id) 
        {
            return _service.ListEventPart(id);
        }
    }
}