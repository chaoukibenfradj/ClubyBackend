using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clubyApi.Controllers
{
     
    [Authorize]

    [Route("api/v1/administrations")]
    [ApiController]

    public class AdministrationController:ControllerBase
    {
        private readonly IAdministrationService _service;
        private readonly IUserService _userservice;
        public AdministrationController(IAdministrationService service,IUserService userService){
               _service=service;
               _userservice=userService;
        }
        [Authorize(Roles=Role.Admin)]
        [HttpPost("createAdministration")]
        ActionResult<Administration> createAdministration([FromBody]Administration administration,User user){

            User user1=_userservice.Register(user);
            administration.User=new MongoDB.Driver.MongoDBRef("User",user1.Id);
            
            return Ok( _service.createAdministration(administration));
        }
        
    }
}