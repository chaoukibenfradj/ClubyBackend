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
using System.Linq;

namespace clubyApi.Repositories
{
    public class ClubRepository:IClubRepository
    {
        private readonly IMongoCollection<Club> _clubs;
        private readonly IMongoCollection<Institute> _institutes;
        private readonly IMongoCollection<Domain> _domains;
        private readonly IMongoCollection<User> _users;



        
        public ClubRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clubs = database.GetCollection<Club>(settings.ClubCollectionName); 
            _domains=database.GetCollection<Domain>(settings.DomainCollectionName); 
          _institutes=database.GetCollection<Institute>(settings.InstituteCollectionName); 
        _users=database.GetCollection<User>(settings.UserCollectionName); 



        }

       
        public  Club FindClubProfile(string id){
              Club resultat=null;
                    if(_clubs.AsQueryable().Where(club=> club.Id==id).FirstOrDefault().Institute.Id==null &&
                    _clubs.AsQueryable().Where(club=> club.Id==id).FirstOrDefault().Domain.Id==null ){
                    var query=from club in _clubs.AsQueryable().Where(club=> club.Id==id) 
                    join u in _users.AsQueryable() on club.User.Id equals u.Id                
                    select 
                    new Club(){
                        Id=club.Id,
                        Institute=club.Institute,
                        Photo=club.Photo,
                        Domain=club.Domain,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
           
            }
            else{
                   var query=from club in _clubs.AsQueryable().Where(club=> club.Id==id) 
                    join u in _users.AsQueryable() on club.User.Id equals u.Id 
                     join domain in _domains.AsQueryable() on club.Domain.Id equals domain.Id      
                     join Institute in _institutes.AsQueryable() on club.Institute.Id equals Institute.Id              
        
                    select 
                    new Club(){
                        Id=club.Id,
                        Institute=Institute,
                        Photo=club.Photo,
                        Domain=domain,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            }
           
           
            
            return resultat;
        }

        public UpdateResult CompleteClubInscription(string id,string institute, string photo)
        {
            var filter = Builders<Club>.Filter.Eq("id",id);
            Console.Write(institute);

            var update=Builders<Club>.Update.Set("Photo", photo).Set("Institute", institute);

            return _clubs.UpdateOne(filter,update);
        }

        public Club CreateClub(User user,Institute institute,Domain domain)
        {
            Club resultat=new Club(user,institute,domain);
            Console.Write(resultat);
             _clubs.InsertOne(resultat);
             return resultat;
        }
    }

    
}