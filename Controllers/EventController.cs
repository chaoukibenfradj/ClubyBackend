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
        [HttpGet("")]
        public ActionResult<List<Event>> ShowAllEvents() 
        {
            return Ok(_service.ShowAllEvents());
        }
        [HttpGet("clubfilter/{club}")]
        public ActionResult<List<Event>> ShowEventByClub([FromRoute] string club) 
        {
            return Ok(_service.FindEventByClub(club));
        }
        [HttpGet("datefilter/{date}")]
        public ActionResult<List<Event>> ShowEventByDate([FromRoute] string date) 
        {
            return Ok(_service.FindEventByClub(date));
        }
        [HttpGet("institutefilter/{institute}")]
        public ActionResult<List<Event>> ShowEventByInstitute([FromRoute] string institute) 
        {
            return Ok(_service.FindEventByClub(institute));
        }
         [HttpGet("institutedomain/{domain}")]
        public ActionResult<List<Event>> ShowEventByDomain([FromRoute] string domain) 
        {
            return Ok(_service.FindEventByClub(domain));
        }
        
    }
}