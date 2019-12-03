using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using clubyApi.Helper;
using clubyApi.Models;
using clubyApi.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public class UserRepository : IUserRepository
    {   

        private readonly IMongoCollection<User> _users;
        private readonly AppSettings _appsettings;
        
        public UserRepository(IOptions<AppSettings> appSettings, IClubyDatabaseSettings settings){
            _appsettings=appSettings.Value;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users= database.GetCollection<User>(settings.UserCollectionName); 

        }
        public User Authentificate(Authentification auth)
        {
            User result=null;
            User user=FindUserByEmail(auth.Email);
            if(user!=null){
                 HashPassword hashPassword=new HashPassword();
                if(user.Password == hashPassword.HashedPass(auth.Password)){
                    
                    var key = Encoding.ASCII.GetBytes(_appsettings.Secret);    
                    var jwtToken = new SecurityTokenDescriptor {    
                    Subject = new ClaimsIdentity(new Claim[] {    
                        new Claim(ClaimTypes.Name, user.Id.ToString())    
                    }),    
                    Expires = DateTime.UtcNow.AddMinutes(30),    
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)    
                            };    
                    var tokenHandler = new JwtSecurityTokenHandler();    
                    var token = tokenHandler.CreateToken(jwtToken);    
                    user.Token = tokenHandler.WriteToken(token); 


                    result=user;
                }

            }
            return result;
        
        }

        

        public User Register(User user)
        {
             User result=null;
            if(FindUserByEmail(user.Email)==null){
                result=user;
                var hashPassword=new HashPassword();
                user.Password=hashPassword.HashedPass(user.Password);
                _users.InsertOne(new User(user));
            }
            return result;
        }
        public User FindUserByEmail(string email) => _users.Find<User>(user => user.Email == email).FirstOrDefault();
    }
}