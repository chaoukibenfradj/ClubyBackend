using System.Collections.Generic;
using clubyApi.Models;
using clubyApi.Services;
using ClubyBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace clubyApi.Controllers
{   
    
    [Authorize]
    [Route("api/v1/users")]
    [ApiController]
    public class UserController:ControllerBase
    {   
        private readonly IUserService _userservice;
        private readonly IStudentService _studentservice;
        private readonly IClubService _clubservice;
        private readonly ISponsorService _sponsorservice;
        public UserController(IUserService userService , IStudentService studentService,IClubService clubservice,ISponsorService sponsorService){
            _userservice=userService;
            _studentservice=studentService;
            _clubservice=clubservice;
            _sponsorservice=sponsorService;
        }  
         
        [AllowAnonymous]

        [HttpPost("register")]
        public ActionResult<User> RegisterUser([FromBody] User user)
        {
            User response=_userservice.Register(user);
           if(response.Role.Equals(Role.Student)){

                _studentservice.CreateStudent(response);
                
            }
            else 
            if(response.Role.Equals(Role.Club)){
                _clubservice.CreateClub(response);

            }
            else
            if(response.Role.Equals(Role.Sponsor)){
                _sponsorservice.CreateSponsor(response);

            }
            
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("authentificate")]
        public ActionResult<User> AuthentificateUser([FromBody] Authentification user) 
        {
            User response=_userservice.Authentificate(user);    
            if(response==null){
                return  BadRequest(new {message=" wrong email or password "});
            }   
            
            return Ok(response);
            
        }
        [AllowAnonymous]
      
        [HttpGet("Sendsemails")]
        public ActionResult<List<Email>> getEmailsBySenderId([FromBody]string id) 
        {
            List<Email> response=_userservice.FindEmailBySenderId(id);    
             if(response==null){
                return  BadRequest(new {message="no emails found"});
            }   
            
            return Ok(response);
            
        }
        
        
        [AllowAnonymous]
      
        [HttpGet("Receivedemails")]
        public ActionResult<List<Email>> getEmailsByReceiverId([FromBody]string id) 
        {
            List<Email> response=_userservice.FindEmailByReceiverId(id);    
             if(response==null){
                return  BadRequest(new {message="no emails found"});
            } 
            
            return Ok(response);
            
        }
        [AllowAnonymous]
      
        [HttpPost("mails")]
        public ActionResult<Email> sendEmail([FromBody] Email email,string sender,string receiver) 
        {
         
           
            Email response=_userservice.SendEmail(email,sender,receiver);

            if(response==null){
                 return  BadRequest(new {message="something went wrong"});
            }
            return Ok(response);
            
        }
    }
}