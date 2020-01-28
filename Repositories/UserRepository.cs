using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using clubyApi.Helper;
using clubyApi.Models;
using clubyApi.Utils;
using ClubyBackend.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
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
       //  public User FindUserByIf(string id) => _users.Find<User>(user => user.Id == id).FirstOrDefault();
        public List<Email> FindEmailBySenderId(string id){
                List<Email> emails=new List<Email>();
                 var query=from email in _emails.AsQueryable().Where(Email=>Email.Sender.Id==id) 
                    join u in _users.AsQueryable() on email.Sender.Id equals u.Id                
                    select 
                    new Email(){
                        Id=email.Id,
                        Subject=email.Subject,
                        Content=email.Content,
                        Sender=u,
                        SendDate=email.SendDate,
                        Receiver=email.Receiver
                    };
                   query.ToList().ForEach(mail=>{
                        User rec=FindUserById(mail.Receiver.Id);
                        emails.Add(new Email(mail.Id,mail.Subject,mail.Content,mail.Sender,mail.SendDate,rec));

                    });
           
            
           

            return emails;

         }

        public User FindUserById(string id) => _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public List<Email> FindEmailByReceiverId(string id){
             List<Email> emails=new List<Email>();
             var query=from email in _emails.AsQueryable().Where(Email=>Email.Receiver.Id==id) 
                    join u in _users.AsQueryable() on email.Receiver.Id equals u.Id                
                    select 
                    new Email(){
                        Id=email.Id,
                        Subject=email.Subject,
                        Content=email.Content,
                        Sender=email.Sender,
                        SendDate=email.SendDate,
                        Receiver=u
                    };
                   
                    query.ToList().ForEach(mail=>{
                        User send=FindUserById(mail.Sender.Id);
                        emails.Add(new Email(mail.Id,mail.Subject,mail.Content,send,mail.SendDate,mail.Receiver));

                    });
            
           

            return emails;
    

         }
         
        public Email SendEmail(EmailDto email){
            Email response=null;
           /* var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email.Sender, "sender");
            var subject = email.Subject;
            var to = new EmailAddress(email.Receiver, "receiver");
            var plainTextContent = email.Content;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent,htmlContent);
            var resp =  client.SendEmailAsync(msg);*/
            User sen=FindUserByEmail(email.Sender);
            User rec=FindUserByEmail( email.Receiver);
            if(sen==null || rec==null){
                   return response;
            }
            else{ 
                Email mail=new Email(email,sen,rec);
                _emails.InsertOne(mail);
                response=mail;
               
           }
            return response;
    }

    }
    
}