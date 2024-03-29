using System;
using System.Collections.Generic;
using System.Linq;
using clubyApi.Utils;
using clubyApi.Models;
using ClubyBackend.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using clubyApi.Helper;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;




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
        
        //find club by user id
        public  Club FindClub(string id){
              Club resultat=null;
                    if(_clubs.AsQueryable().Where(club=> club.User.Id==id).FirstOrDefault().Institute.Id==null &&
                    _clubs.AsQueryable().Where(club=> club.User.Id==id).FirstOrDefault().Domain.Id==null ){
                    var query=from club in _clubs.AsQueryable().Where(club=> club.User.Id==id) 
                    join u in _users.AsQueryable() on club.User.Id equals u.Id                
                    select 
                    new Club(){
                        Id=club.Id,
                        Name=club.Name,
                        Description=club.Description,
                        Institute=club.Institute,
                        Photo=club.Photo,
                        Domain=club.Domain,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
           
            }
            else if(_clubs.AsQueryable().Where(club=> club.User.Id==id).FirstOrDefault().Institute.Id!=null &&
                    _clubs.AsQueryable().Where(club=> club.User.Id==id).FirstOrDefault().Domain.Id==null){
                   var query=from club in _clubs.AsQueryable().Where(club=> club.User.Id==id) 
                    join u in _users.AsQueryable() on club.User.Id equals u.Id 
                     join Institute in _institutes.AsQueryable() on club.Institute.Id equals Institute.Id              
        
                    select 
                    new Club(){
                        Id=club.Id,
                        Name=club.Name,
                        Institute=Institute,
                        Description=club.Description,
                        Photo=club.Photo,
                        Domain=club.Domain,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            }
             else if(_clubs.AsQueryable().Where(club=> club.User.Id==id).FirstOrDefault().Institute.Id==null &&
                    _clubs.AsQueryable().Where(club=> club.User.Id==id).FirstOrDefault().Domain.Id!=null){
                   var query=from club in _clubs.AsQueryable().Where(club=> club.User.Id==id) 
                    join u in _users.AsQueryable() on club.User.Id equals u.Id 
                     join domain in _domains.AsQueryable() on club.Domain.Id equals domain.Id      
        
                    select 
                    new Club(){
                        Id=club.Id,
                        Name=club.Name,
                        Institute=club.Institute,
                        Description=club.Description,
                        Photo=club.Photo,
                        Domain=domain,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            }
              else{
                   var query=from club in _clubs.AsQueryable().Where(club=> club.User.Id==id) 
                    join u in _users.AsQueryable() on club.User.Id equals u.Id 
                     join domain in _domains.AsQueryable() on club.Domain.Id equals domain.Id   
                      join Institute in _institutes.AsQueryable() on club.Institute.Id equals Institute.Id        
        
                    select 
                    new Club(){
                        Id=club.Id,
                        Name=club.Name,
                        Institute=Institute,
                        Description=club.Description,
                        Photo=club.Photo,
                        Domain=domain,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            }
           
           
            
            return resultat;
        }
        //find club by club id 
        public  Club FindClubProfile(string id){
              Club resultat=null;
                    if(_clubs.AsQueryable().Where(club=> club.Id==id).FirstOrDefault().Institute.Id==null &&
                    _clubs.AsQueryable().Where(club=> club.Id==id).FirstOrDefault().Domain.Id==null   
                   ){
                    var query=from club in _clubs.AsQueryable().Where(club=> club.Id==id) 
                    join u in _users.AsQueryable() on club.User.Id equals u.Id                
                    select 
                    new Club(){
                        Id=club.Id,
                        Name=club.Name,
                        Institute=club.Institute,
                        Photo=club.Photo,
                        Description=club.Description,
                        CreationDate=club.CreationDate,
                        Domain=club.Domain,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
           
            }
             else if(_clubs.AsQueryable().Where(club=> club.Id==id).FirstOrDefault().Institute.Id==null &&
                    _clubs.AsQueryable().Where(club=> club.Id==id).FirstOrDefault().Domain.Id!=null   
                   ){
                   var query=from club in _clubs.AsQueryable().Where(club=> club.Id==id) 
                    join u in _users.AsQueryable() on club.User.Id equals u.Id 
                     join domain in _domains.AsQueryable() on club.Domain.Id equals domain.Id      
        
                    select 
                    new Club(){
                        Id=club.Id,
                        Name=club.Name,
                        Institute=club.Institute,
                        Photo=club.Photo,
                          Description=club.Description,
                        CreationDate=club.CreationDate,
                        Domain=domain,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            }
             else if(_clubs.AsQueryable().Where(club=> club.Id==id).FirstOrDefault().Institute.Id!=null &&
                    _clubs.AsQueryable().Where(club=> club.Id==id).FirstOrDefault().Domain.Id==null 
                    ){
                   var query=from club in _clubs.AsQueryable().Where(club=> club.Id==id) 
                    join u in _users.AsQueryable() on club.User.Id equals u.Id 
                     join Institute in _institutes.AsQueryable() on club.Institute.Id equals Institute.Id              
        
                    select 
                    new Club(){
                        Id=club.Id,
                        Name=club.Name,
                        Institute=club.Institute,
                        Photo=club.Photo,
                        Domain=club.Domain,
                          Description=club.Description,
                        CreationDate=club.CreationDate,
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
                        Name=club.Name,
                        Institute=Institute,
                        Photo=club.Photo,
                        Domain=domain,
                          Description=club.Description,
                        CreationDate=club.CreationDate,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            }
           
           
            
            return resultat;
        }

       public UpdateResult CompleteClubInscription(UpdateDto club)
       {
          UpdateResult result=null;
          
              var filter=Builders<Club>.Filter.Eq("Id",club.Id);
              if(club.Photo!=null && club.Description!=null && club.Name!=null && club.Domain!=null && club.Institute!=null){
                var update=Builders<Club>.Update.Set("Photo",club.Photo).Set("Description",club.Description)
                .Set("Name",club.Name).Set("Institut",new Institute(club.Institute)).Set("Domain",new Domain(club.Domain));
                result=_clubs.UpdateOne(filter,update);
              }
              else if(club.Domain!=null && club.Institute!=null){
                   var update=Builders<Club>.Update.Set("Institut",new Institute(club.Institute)).Set("Domain",new Domain(club.Domain));
                result=_clubs.UpdateOne(filter,update);

              }
                else if(club.Domain!=null){
                   var update=Builders<Club>.Update.Set("Domain",new Domain(club.Domain));
                result=_clubs.UpdateOne(filter,update);

              }
                else if(club.Institute!=null){
                   var update=Builders<Club>.Update.Set("Institut",new Institute(club.Institute));
                   result=_clubs.UpdateOne(filter,update);

              }
               else if(club.Photo!=null && club.Description!=null && club.Name!=null && club.Domain!=null && club.Institute!=null
                && club.LastName!=null 
                && club.FirstName!=null
                ){
                var update_1=Builders<Club>.Update.Set("Photo",club.Photo).Set("Description",club.Description).Set("Name",club.Name).Set("Institut",new Institute(club.Institute))
                .Set("Domain",new Domain(club.Domain));

                var update_2=Builders<User>.Update.Set("LastName",club.LastName).Set("FirstName",club.FirstName);
                Club s=_clubs.Find(s=>s.Id==club.Id).FirstOrDefault();
                _users.UpdateOne(Builders<User>.Filter.Eq("Id",s.User.Id),update_2);
                result=_clubs.UpdateOne(filter,update_1);
              }
               else if(club.Photo!=null){
                var update=Builders<Club>.Update.Set("Photo",club.Photo);
                result=_clubs.UpdateOne(filter,update);

              }
               else if(
                club.LastName!=null 
                && club.FirstName!=null){
                var update_2=Builders<User>.Update.Set("LastName",club.LastName).Set("FirstName",club.FirstName);
                Club s=_clubs.Find(s=>s.Id==club.Id).FirstOrDefault();
               result= _users.UpdateOne(Builders<User>.Filter.Eq("Id",s.User.Id),update_2);
               
              }
              
               return result;
       }

        public Club CreateClub(User user,Institute institute,Domain domain)
        {
            Club resultat=new Club(user,institute,domain);
         
             _clubs.InsertOne(resultat);
             return resultat;
        }

      


         public List<Club> ShowAllClubs()
             {
              
              List<Club>clubs=new List<Club>();
          
             var query=from e in _clubs.AsQueryable()
                   // join d in _domains.AsQueryable() on e.Domain.Id equals d.Id   
                    //join inst in _institutes.AsQueryable() on e.Institute.Id equals inst.Id 
                    join u in _users.AsQueryable() on e.User.Id equals u.Id             
                    select 
                    new Club(){
                        Id=e.Id,
                        Name=e.Name,
                        Description=e.Description,
                        Photo=e.Photo,
                        Domain=e.Domain,
                        CreationDate=e.CreationDate,
                        Institute=e.Institute,
                        User=u
                     
                    };
                   query.ToList().ForEach(club =>{
                       if(club.Domain.Id==null && club.Institute.Id==null){
                           clubs.Add(club);
                       }
                       else
                       if(club.Domain.Id!=null && club.Institute.Id!=null){
                           var q=from e in _clubs.AsQueryable().Where(c=>c.Id==club.Id)
                            join d in _domains.AsQueryable() on e.Domain.Id equals d.Id   
                            join inst in _institutes.AsQueryable() on e.Institute.Id equals inst.Id 
                            join u in _users.AsQueryable() on e.User.Id equals u.Id             
                            select 
                            new Club(){
                                Id=e.Id,
                                Name=e.Name,
                                Description=e.Description,
                                Photo=e.Photo,
                                Domain=d,
                                CreationDate=e.CreationDate,
                                Institute=inst,
                                User=u
                            
                            };
                            clubs.Add(q.FirstOrDefault());

                       }
                        else
                       if(club.Domain.Id!=null && club.Institute.Id==null){
                           var q=from e in _clubs.AsQueryable().Where(c=>c.Id==club.Id)
                            join d in _domains.AsQueryable() on e.Domain.Id equals d.Id   
                            join u in _users.AsQueryable() on e.User.Id equals u.Id             
                            select 
                            new Club(){
                                Id=e.Id,
                                Name=e.Name,
                                Description=e.Description,
                                Photo=e.Photo,
                                Domain=d,
                                CreationDate=e.CreationDate,
                                Institute=e.Institute,
                                User=u
                            
                            };
                            clubs.Add(q.FirstOrDefault());

                       }
                        else
                       if(club.Domain.Id==null && club.Institute.Id!=null){
                           var q=from e in _clubs.AsQueryable().Where(c=>c.Id==club.Id)
                            join inst in _institutes.AsQueryable() on e.Institute.Id equals inst.Id 
                            join u in _users.AsQueryable() on e.User.Id equals u.Id             
                            select 
                            new Club(){
                                Id=e.Id,
                                Name=e.Name,
                                Description=e.Description,
                                Photo=e.Photo,
                                Domain=e.Domain,
                                CreationDate=e.CreationDate,
                                Institute=inst,
                                User=u
                            
                            };
                            clubs.Add(q.FirstOrDefault());

                       }

                   });
                   
            return clubs;
        }

         public Club DeleteClub(string id)
        {
            return _clubs.FindOneAndDelete(d=>d.Id==id);
        }


        




























    }

    
}