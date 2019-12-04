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
    public class ClubsController :ControllerBase
    {   
        private  readonly IClubService _service;


        public ClubsController(IClubService service){
             _service=service;
        }

       
        [HttpGet("profile/{id}")]
        public ActionResult<Club> FindClubProfile(string id) 
        {
            return Ok(_service.FindClubProfile(id));
        }
        [HttpPost]
        public ActionResult<UpdateResult> CompleteClubInscription(string id, string institute, string photo){
            return Ok(_service.CompleteClubInscription(id,institute,photo));
        }

       

      
    }
}