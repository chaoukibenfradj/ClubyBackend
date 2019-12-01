using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace clubyApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentsController :ControllerBase
    {   
        private  readonly IStudentService _service;
        public StudentsController(IStudentService service){
             _service=service;
        }
        [HttpPost("register")]
        public ActionResult<Inscription> CreateStudent(Inscription student)
        {
            Inscription response=_service.CreateStudent(student);
            return Ok(response);
        }
        [HttpPost("login")]
        public ActionResult<Student> AuthentificateStudent(Authentification student) 
        {
            Student response=_service.AuthentificateStudent(student.Email,student.Password);    
            if(response==null){
                return NotFound();
            }   
            else{
                return Ok(response);
            }  
        }
        [HttpGet("{id}")]
        public ActionResult<Student> FindStudentProfile(string id) 
        {
            return Ok(_service.FindStudentProfile(id));
        }

       

      
    }
}