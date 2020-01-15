using clubyApi.Models;
using clubyApi.Services;
using ClubyBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace clubyApi.Controllers
{
     
    [Authorize]
    [Route("api/v1/admins")]
    [ApiController]
    public class AdministrationController:ControllerBase
    {
        private readonly IAdministrationService _service;
        private readonly IUserService _userservice;
        public AdministrationController(IAdministrationService service,IUserService userService){
               _service=service;
               _userservice=userService;
        }
        //[Authorize(Roles=Role.Admin)]
        [AllowAnonymous]
        [HttpPost("")]
        public ActionResult<User> createAdministration([FromBody] AdministrationDto admin){

            User user1=_userservice.Register(new User(admin.Firstname,admin.Lastname,admin.Email,Role.Administrator,admin.Password));
            if(user1==null){
                return BadRequest(new {message="email is already in use"});
            }
            else{
            Administration administration1=new Administration(admin.Institute,user1);  
            _service.CreateAdmin(administration1);          
            return Ok( user1);

            }
         
        }
         [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Administration> FindAdministrator(string id){
            Administration res= _service.FindAdminProfile(id);
            if(res==null){
                return BadRequest(new {message=" could not find admin"});
            }
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpPut("{id}")]
        public ActionResult<Administration> ModifyAdmin([FromBody]string administration,string id){
            Administration res= _service.ModifyAdmin(id,administration);
            if(res==null){
                return BadRequest(new {message=" cannot update admin "});
            }
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public ActionResult<Administration> DeleteAdmin(string id){
            Administration res=_service.DeleteAdmin(id);
            if(res==null){
                return BadRequest(new {message=" cannot update admin "});
            }
            return Ok(res);
            
        }
     
    }
}