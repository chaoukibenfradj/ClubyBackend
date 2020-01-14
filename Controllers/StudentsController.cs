using clubyApi.Models;
using clubyApi.Services;
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

        [Authorize(Roles=Role.Student)]
        [HttpGet("{id}")]
        public ActionResult<Student> FindStudentProfile(string id) 
        {
            return Ok(_service.FindStudentProfile(id));
        }
        [Authorize(Roles=Role.Student)]
        [HttpPut("{id}")]

        public ActionResult<Student> UpdateStudentProfile(string id,string photo,string institute) 
        {
            Console.WriteLine(institute.Length);

            Student res=_service.UpdateStudentProfile(id,photo,institute);
            if(res==null){
               return  BadRequest(new {message=" unable to update"});
            }
            return Ok(res);
        }
       
       

      
    }
}