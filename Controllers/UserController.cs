using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clubyApi.Controllers
{   [Authorize]
    [Route("api/v1/users")]
    [ApiController]
    public class UserController:ControllerBase
    {   
        private readonly IUserService _userservice;
        private readonly IStudentService _studentservice;
        public UserController(IUserService userService , IStudentService studentService){
            _userservice=userService;
            _studentservice=studentService;
        }
         
        [AllowAnonymous]

        [HttpPost("register")]
        public ActionResult<User> RegisterUser([FromBody] User user)
        {
            User response=_userservice.Register(user);
           /* if(response.Role.Equals(Role.Student)){
                _studentservice.CreateStudent(user);
                
            }*/
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("authentificate")]
        public ActionResult<User> AuthentificateUser([FromBody] Authentification user) 
        {
            User response=_userservice.Authentificate(user);    
            if(response==null){
                return  BadRequest(new {message=" wrong email or password "});
            }   
            
            return Ok(response);
            
        }
        
    }
}