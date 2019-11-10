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
        [HttpPost]
        public ActionResult<Student> Create(Student student)
        {
            _service.Create(student);
            return student;
        }
      
    }
}