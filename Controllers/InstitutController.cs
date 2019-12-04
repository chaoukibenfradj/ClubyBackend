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
    public class InstitutsController :ControllerBase
    {   
        private  readonly IInstitutService _service;
        public InstitutsController(IInstitutService service){
             _service=service;
        }

       
        [HttpGet("profile/{id}")]
        public ActionResult<Institut> FindInstitutProfile(string id) 
        {
            return Ok(_service.FindInstitutProfile(id));
        }
        [HttpPost]
        public ActionResult<UpdateResult> CompleteInstitutInscription(string id, string name, string region){
            return Ok(_service.CompleteInstitutInscription(id,name,region));
        }

       

      
    }
}