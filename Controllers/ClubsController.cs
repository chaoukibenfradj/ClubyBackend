using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using ClubyBackend.Models;


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

         [AllowAnonymous]
        [HttpPut()]
        public ActionResult<UpdateResult> CompleteClubInscription(UpdateDto club){
            return Ok(_service.CompleteClubInscription(club));
        }

        

       
        [AllowAnonymous]
        [HttpGet("")]
        public ActionResult<List<Club>> ShowAllClubs() 
        {
            return Ok(_service.ShowAllClubs());
        }     

        [AllowAnonymous]
        [HttpDelete("{id}")]
         public ActionResult<Club> DeleteClub(string id){
            Club res=_service.DeleteClub(id);
            if(res==null){
                return BadRequest(new {message=" cannot delete club "});
            }
            return Ok(res);
        } 
       

      
    }
}