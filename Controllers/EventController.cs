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

        [HttpGet("{club}")]
        public ActionResult<List<Event>> ShowEventByClub(string club) 
        {
            return Ok(_service.FindEventByClub(club));
        }
        [AllowAnonymous]

        [HttpGet("{date}")]
        public ActionResult<List<Event>> ShowEventByDate(string date) 
        {
            return Ok(_service.FindEventByDomain(date));
        }
        [AllowAnonymous]

        [HttpGet("{institute}")]
        public ActionResult<List<Event>> ShowEventByInstitute(string institute) 
        {
            return Ok(_service.FindEventByInstitute(institute));
        }
        [AllowAnonymous]

         [HttpGet("{domain}")]
        public ActionResult<List<Event>> ShowEventByDomain(string domain) 
        {
            return Ok(_service.FindEventByDomain(domain));
        }
        
    }
}