using clubyApi.Models;
using clubyApi.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
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

        [AllowAnonymous]
        [HttpGet("")]
        public ActionResult<List<Sponsor>> ShowAllSponsors() 
        {
            return Ok(_service.ShowAllSponsors());
        }
         [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Sponsor> FindSponsorProfile(string id) 
        {
            return Ok(_service.FindSponsorProfile(id));
        }
          [AllowAnonymous]
         [HttpGet("user/{id}")]
        public ActionResult<Sponsor> FindSponsor(string id) 
        {
            Console.Write(id);
            return Ok(_service.FindSponsor(id));
        }
       
    }

   
}