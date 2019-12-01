using clubyApi.Models;
using clubyApi.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


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

        [HttpDelete("{id}")]// 
        public IActionResult Delete(string id)
        {
            _service.remove(id);

            return NoContent();
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Club clubIn)
        {
            var club = _service.Get(id);

            if (club == null)
            {
                return NotFound();
            }

            _service.Update(id, clubIn);

            return NoContent();
        }

        [HttpGet("{id:length(24)}", Name = "GetClub")] //Get club by id
        public ActionResult<Club> Get(string id)
        {
            var c = _service.Get(id);

            if (c == null)
            {
                return NotFound();
            }
            return c;
        }

        [HttpGet] // get list of all clubs
        public ActionResult<List<Club>> Get() =>
            _service.Get();

      
    }
}