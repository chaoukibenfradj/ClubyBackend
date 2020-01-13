using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using clubyApi.Helper;
using clubyApi.Models;
using clubyApi.Utils;
using ClubyBackend.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace clubyApi.Repositories
{
    public class UserRepository : IUserRepository
    {   
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<Email> _emails;

        private readonly AppSettings _appsettings;
        public UserRepository(IOptions<AppSettings> appSettings, IClubyDatabaseSettings settings){
            _appsettings=appSettings.Value;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users= database.GetCollection<User>(settings.UserCollectionName); 
            _emails= database.GetCollection<Email>(settings.EmailCollectionName); 


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
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Role,user.Role)
                    }),    
                    Expires = DateTime.UtcNow.AddDays(2),    
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
                var hashPassword=new HashPassword();
                user.Password=hashPassword.HashedPass(user.Password);
                _users.InsertOne(new User(user));
                result=FindUserByEmail(user.Email);
            }
            return result;
        }
        public User FindUserByEmail(string email) => _users.Find<User>(user => user.Email == email).FirstOrDefault();
        public List<Email> FindEmailBySenderId(string id){
            return _emails.Find<Email>(e => e.Sender.Id == id).ToList<Email>();

         }
        public List<Email> FindEmailByReceiverId(string id){
            return _emails.Find<Email>(e => e.Receiver.Id == id).ToList<Email>();


         }
        public Email SendEmail(Email email,string sender,string receiver){
             var apiKey = Environment.GetEnvironmentVariable("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");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(
              sender, "sender");
            var subject = email.Subject;
            var to = new EmailAddress(receiver, "receiver");
            var plainTextContent = email.Content;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent,htmlContent);
            var response =  client.SendEmailAsync(msg);
               User sen=FindUserByEmail(sender);
               User rec=FindUserByEmail( receiver);
               if(sen==null || rec==null){
                   return null;
               }
              else{ Email mail=new Email(email,sen,rec);
                _emails.InsertOne(mail);
                return mail;
           }
            }
    }
}