using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace clubyApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClubsController :ControllerBase
    {   
        private readonly ClubService _service;
        public ClubsController(ClubService service){
             _service=service;
        }
        [HttpPost("register")]
        [Produces("application/json")]
        public ActionResult<string> Create(Club club)
        {
            string response=_service.Create(club);
            return Ok(new ObjectResult(response));
        }
        [HttpPost("login")]
        [Produces("application/json")]
        public ActionResult<string> Login(Club club) 
        {
            string response=_service.Login(club.Email,club.Password);         
            return Ok(new ObjectResult(response));
        }

      
    }
}