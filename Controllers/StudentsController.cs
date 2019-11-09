using clubyApi.Models;
using clubyApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace clubyApi.Controllers
{
    [Route("api/studentsapi")]
    [ApiController]
    public class StudentsController :ControllerBase
    {   
        private readonly StudentsService _service;
        public StudentsController(StudentsService service){
             _service=service;
        }
        [HttpPost]
       // [Route("/register")]
        public ActionResult<Student> Create(Student student)
        {
            student.Password=HashedPass(student.Password);
            _service.Create(student);
            return student;
        }
        string HashedPass(string password){
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
                return hashed;
        }
    }
}