using clubyApi.Models;
using clubyApi.Services;
using ClubyBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
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

        //[Authorize(Roles=Role.Student)]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Student> FindStudentProfile(string id) 
        {
            return Ok(_service.FindStudentProfile(id));
        }
         //[Authorize(Roles=Role.Student)]
        [AllowAnonymous]
        [HttpGet("user/{id}")]
        public ActionResult<Student> FindStudent(string id) 
        {
            return Ok(_service.FindStudent(id));
        }
        //[Authorize(Roles=Role.Student)]
        [AllowAnonymous]
        [HttpPut("")]

        public ActionResult<UpdateResult> UpdateStudentProfile(UpdateDto student) 
        {

            UpdateResult res=_service.UpdateStudentProfile(student);
            if(res==null){
               return  BadRequest(new {message=" unable to update"});
            }
            return Ok(res);
        }
       
       

      
    }
}