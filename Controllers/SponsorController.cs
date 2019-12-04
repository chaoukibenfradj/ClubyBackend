using clubyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clubyApi.Controllers
{
    [Authorize]

    [Route("api/v1/[controller]")]
    [ApiController]
    public class SponsorController:ControllerBase
    {
        private readonly ISponsorService _service;
        public SponsorController(ISponsorService service){
            _service=service;
        }
    }
}