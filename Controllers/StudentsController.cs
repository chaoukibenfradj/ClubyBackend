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
    public class StudentsController :ControllerBase
    {   
        private  readonly IStudentService _service;
        public StudentsController(IStudentService service){
             _service=service;
        }

        
        [AllowAnonymous]

        [HttpPost("register")]
        public ActionResult<Inscription> CreateStudent([FromBody] Inscription student)
        {
            Inscription response=_service.CreateStudent(student);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("authentificate")]
        public ActionResult<Student> AuthentificateStudent([FromBody] Authentification student) 
        {
            Student response=_service.AuthentificateStudent(student);    
            if(response==null){
                return  BadRequest(new {message=" wrong email or password "});
            }   
            
            return Ok(response);
            
        }
        [HttpGet("profile/{id}")]
        public ActionResult<Student> FindStudentProfile(string id) 
        {
            return Ok(_service.FindStudentProfile(id));
        }
        [HttpPost]
        public ActionResult<UpdateResult> CompleteStudentInscription(string id, string institute, string photo){
            return Ok(_service.CompleteStudentInscription(id,institute,photo));
        }

       

      
    }
}