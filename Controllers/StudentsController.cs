using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace clubyApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentsController :ControllerBase
    {   
        private readonly StudentsService _service;
        public StudentsController(StudentsService service){
             _service=service;
        }
        [HttpPost("register")]
        [Produces("application/json")]
        public ActionResult<string> Create(Student student)
        {
            string response=_service.Create(student);
            return Ok(new ObjectResult(response));
        }
        [HttpPost("login")]
        [Produces("application/json")]
        public ActionResult<string> Login(Student student) 
        {
            string response=_service.Login(student.Email,student.Password);         
            return Ok(new ObjectResult(response));
        }

        [HttpGet("profile")]
        [Produces("application/json")]
        public ActionResult<Student> GetProfile(string id)
        {  id=Request.Headers["id"];
        
           return Ok(new ObjectResult( _service.GetProfile(id)));   
        }

      
    }
}