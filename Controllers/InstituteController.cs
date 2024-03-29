using System.Collections.Generic;
using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace clubyApi.Controllers
{   
    [Authorize]
    [Route("api/v1/institutes")]
    [ApiController]
    public class InstituteController :ControllerBase
    {   
        private  readonly IInstituteService _service;
        public InstituteController(IInstituteService service){
             _service=service;
        }
        //[Authorize(Roles=Role.Admin)]
        [AllowAnonymous]

        [HttpPost("")]
        public ActionResult<Institute> CreateInstitute([FromBody]Institute institute){
            Institute res=_service.CreateInstitute(institute);
            if(res==null){
                return BadRequest(new {message=" institute with the same name already exists "});
            }
            return Ok(res);
        }
        //[Authorize(Roles=Role.Admin)]
        [AllowAnonymous]

        [HttpPut("{id}")]
        public ActionResult<Institute> ModifyInstitute(string id,[FromBody]Institute institute){
             Institute res=_service.ModifyInstitute(id,institute);
            if(res==null){
                return BadRequest(new {message="Could not update institute"});
            }
           
            return Ok(res);
        }
          //[Authorize(Roles=Role.Admin)]
        [AllowAnonymous]

        [HttpDelete("{id}")]
        public ActionResult<Institute> DeleteInstitute(string id){
            Institute res=_service.DeleteInstitute(id);
            if(res==null){
                return BadRequest(new {message="Could not delete institute"});
            }
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpGet("")]

         public ActionResult<List<Institute>> FindAllInstitutes(){
             return Ok(_service.FindAllInstitutes());
         }

        [AllowAnonymous]
        [HttpGet("name/{name}")]

         public ActionResult<Institute> FindInstituteByName(string name){
            Institute res=_service.FindInstituteByName(name);
            if(res==null){
                return NotFound(new {message="there is no institute found"});
            }
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpGet("domain/{domain}")]

         public ActionResult<List<Institute>> FindInstitutebyDomain(string domain){
            List<Institute> res=_service.FindInstituteByDomain(domain);
            if(res==null){
                return NotFound(new {message="there is no institute found"});
            }
            return Ok(res);
        }
         [AllowAnonymous]
        [HttpGet("region/{region}")]

         public ActionResult<List<Institute>> FindInstitutebyRegion(string region){
            List<Institute> res=_service.FindInstituteByRegion(region);
            if(res==null){
                return NotFound(new {message="there is no institute found"});
            }
            return Ok(res);
        }
       
      
    }
}