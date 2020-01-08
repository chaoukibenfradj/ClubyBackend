using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace clubyApi.Controllers
{
    [Authorize]

    [Route("api/v1/[controller]")]
    [ApiController]
    public class SponsorController:ControllerBase
    {
        private readonly ISponsorService _service;
        public SponsorController(ISponsorService service){
            _service=service;
        }

        [AllowAnonymous]
        [HttpGet("")]
        public ActionResult<List<Sponsor>> ShowAllSponsors() 
        {
            return Ok(_service.ShowAllSponsors());
        }
       
    }

   
}