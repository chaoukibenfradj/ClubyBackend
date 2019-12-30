using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPut("{id}")]
         public ActionResult<Domain> UpdateDomain(string id,[FromBody]Domain domain){
            Domain res=_service.ModifyDomain(id,domain);
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

       


    }
}