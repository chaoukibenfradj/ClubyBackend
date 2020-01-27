using System.Collections.Generic;
using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace clubyApi.Controllers
{

    [Authorize]
    [Route("api/v1/domains")]
    [ApiController]
    public class DomainController:ControllerBase
    {
          private  readonly IDomainService _service;
        public DomainController(IDomainService service){
             _service=service;
        }
        //[Authorize(Roles=Role.Admin)]
        [AllowAnonymous]
        [HttpPost("domain")]
         public ActionResult<Domain> CreateDomain([FromBody]Domain domain){
            Domain res=_service.CreateDomain(domain);
            if(res==null){
                return BadRequest(new {message=" cannot create domain "});
            }
            return Ok(res);
        }
        //[Authorize(Roles=Role.Admin)]
        [AllowAnonymous]
        [HttpPut("")]
         public ActionResult<UpdateResult> UpdateDomain([FromBody]Domain domain){
            UpdateResult res=_service.ModifyDomain(domain);
            if(res==null){
                return BadRequest(new {message=" cannot update domain "});
            }
            return Ok(res);
        }
        //[Authorize(Roles=Role.Admin)]
        [AllowAnonymous]
        [HttpDelete("{id}")]
         public ActionResult<Domain> DeleteDomain(string id){
            Domain res=_service.DeleteDomain(id);
            if(res==null){
                return BadRequest(new {message=" cannot delete domain "});
            }
            return Ok(res);
        }

         [AllowAnonymous]
        [HttpGet("")]
         public ActionResult<List<Domain>> FindDomains(){
           
            return Ok(_service.getDomains());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Domain> FindDomain(string id) 
        {   Domain e =_service.FindDomain(id);
            if(e==null){
                 
                return BadRequest(new {message="Could not find this Domain ID"});

            }
            return Ok(e);
        }

       


    }
}