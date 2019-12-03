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

       
        [HttpGet("profile/{id}")]
        public ActionResult<Student> FindStudentProfile(string id) 
        {
            return Ok(_service.FindStudentProfile(id));
        }
       
       

      
    }
}