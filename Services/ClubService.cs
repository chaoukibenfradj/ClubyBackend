using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
using System;
namespace clubyApi.Services
{
    public class ClubService
    {
        private readonly IMongoCollection<Club> _clubs;
        public ClubService(IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clubs = database.GetCollection<Club>(settings.ClubCollectionName); 

        }
        public string Create(Club club){
            string result="email is already in use";
            var hashPassword=new HashPassword();
            long num = _clubs.Find<Club>(c =>c.Email==club.Email).CountDocuments();
            if(num==0){
                result="account created with success";
                club.Password=hashPassword.HashedPass(club.Password);
                _clubs.InsertOne(club);
            }
            return result;
        }
        public string Login(string email,string password){
            string result=null;
            
            Club club = _clubs.Find<Club>(club => club.Email == email).FirstOrDefault();
            if(club==null){
              result="club does not exists";
            }
            else{
                HashPassword hashPassword=new HashPassword();
                if(club.Password == hashPassword.HashedPass(password)){
                    result=club.Id;
                }
                else{

                    result="wrong password";
                }
            }
            return result;
        } 

       

        }



    
}