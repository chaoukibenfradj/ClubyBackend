using System;
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
        public ActionResult<string> Create(Student student)
        {
            string result=_service.Create(student);
            return result;
        }
         [HttpPost("login")]
        public ActionResult<string> Login(Student student)
        {
            string result=_service.Login(student.Email,student.Password);
            return result;
        }
      
    }
}