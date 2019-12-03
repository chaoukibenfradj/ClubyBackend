using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
using System;
using clubyApi.Helper;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace clubyApi.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly IMongoCollection<Student> _students;
        private readonly AppSettings _appsettings;
        
        public StudentRepository(IOptions<AppSettings> appSettings, IClubyDatabaseSettings settings){
            _appsettings=appSettings.Value;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentCollectionName); 

        }

        public Student AuthentificateStudent(Authentification authentification)
        {
            Student result=null;
            Student student=FindStudentByEmail(authentification.Email);
            if(student!=null){
                 HashPassword hashPassword=new HashPassword();
                if(student.Password == hashPassword.HashedPass(authentification.Password)){
                    
                    var key = Encoding.ASCII.GetBytes(_appsettings.Secret);    
                    var jwtToken = new SecurityTokenDescriptor {    
                    Subject = new ClaimsIdentity(new Claim[] {    
                        new Claim(ClaimTypes.Name, student.Id.ToString())    
                    }),    
                    Expires = DateTime.UtcNow.AddMinutes(30),    
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)    
                            };    
                    var tokenHandler = new JwtSecurityTokenHandler();    
                    var token = tokenHandler.CreateToken(jwtToken);    
                    student.Token = tokenHandler.WriteToken(token); 


                    result=student;
                }

            }
            return result;
        }

        public Inscription CreateStudent(Inscription student)
        {   
            Inscription result=null;
            if(FindStudentByEmail(student.Email)==null){
                result=student;
                var hashPassword=new HashPassword();
                student.Password=hashPassword.HashedPass(student.Password);
                _students.InsertOne(new Student(student));
            }
            return result;
        }
        public  Student FindStudentProfile(string id){
            return _students.Find<Student>(Student=> Student.Id==id).FirstOrDefault();
        }
        public Student FindStudentByEmail(string email) => _students.Find<Student>(stud => stud.Email == email).FirstOrDefault();

        public UpdateResult CompleteStudentInscription(string id,string institute, string photo)
        {
            var filter = Builders<Student>.Filter.Eq("id",id);
            Console.Write(institute);

            var update=Builders<Student>.Update.Set("Photo", photo).Set("Institute", institute);

            return _students.UpdateOne(filter,update);
        }
    }

    
}