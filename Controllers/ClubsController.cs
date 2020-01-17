using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

namespace clubyApi.Controllers
{   
    [Authorize]

    [Route("api/v1/clubs")]
    [ApiController]
    public class ClubsController :ControllerBase
    {   
        private  readonly IClubService _service;
        public ClubsController(IClubService service){
             _service=service;
        }

       
       // [Authorize(Roles=Role.Club)]
       [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Club> FindClubProfile(string id) 
        {
            return Ok(_service.FindClubProfile(id));
        }
        // [Authorize(Roles=Role.Club)]
       [AllowAnonymous]
        [HttpGet("user/{id}")]
        public ActionResult<Club> FindClub(string id) 
        {
            return Ok(_service.FindClub(id));
        }

        [Authorize(Roles=Role.Club)]
        [HttpPut("{id}")]
        public ActionResult<UpdateResult> CompleteClubInscription(string id, string institute, string photo){
            return Ok(_service.CompleteClubInscription(id,institute,photo));
        }

       
        [AllowAnonymous]
        [HttpGet("")]
        public ActionResult<List<Club>> ShowAllClubs() 
        {
            return Ok(_service.ShowAllClubs());
        }      
       

      
    }
}