using System;
using System.Collections.Generic;
using System.Linq;
using clubyApi.Models;
using ClubyBackend.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace clubyApi
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly IMongoCollection<Sponsor> _sponsors;
        private readonly IMongoCollection<User> _users;


        public SponsorRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _sponsors = database.GetCollection<Sponsor>(settings.SponsorCollectionName); 
             _users = database.GetCollection<User>(settings.UserCollectionName); 


        }
        public Sponsor CreateSponsor(User user)
        {
             Sponsor resultat=new Sponsor(user);
             _sponsors.InsertOne(resultat);
             return resultat;
        }

        public Sponsor FindSponsor(string id)
        {
           Sponsor resultat=null;
              
                 var query=from s in _sponsors.AsQueryable().Where(Sponsor=> Sponsor.User.Id==id) 
                    join u in _users.AsQueryable() on s.User.Id equals u.Id
                    select 
                    new Sponsor(){
                        Id=s.Id,
                        Entreprise=s.Entreprise,
                        Interests=s.Interests,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            
           
           
            
            return resultat;
        }
        public UpdateResult updateSponsor(UpdateDto sponsor){
             UpdateResult result=null;
          
              var filter=Builders<Sponsor>.Filter.Eq("Id",sponsor.Id);
              if(sponsor.Photo!=null && sponsor.Entreprise!=null){
                var update=Builders<Sponsor>.Update.Set("Photo",sponsor.Photo).Set("Entreprise",sponsor.Entreprise);
                result=_sponsors.UpdateOne(filter,update);
              }
              else if(sponsor.Photo!=null){
                var update=Builders<Sponsor>.Update.Set("Photo",sponsor.Photo);
                result=_sponsors.UpdateOne(filter,update);

              }
               else if(sponsor.Photo!=null 
               && sponsor.Entreprise!=null
                && sponsor.LastName!=null 
                && sponsor.FirstName!=null
                ){
                var update_1=Builders<Sponsor>.Update.Set("Photo",sponsor.Photo).Set("Entreprise",sponsor.Entreprise);
                var update_2=Builders<User>.Update.Set("LastName",sponsor.LastName).Set("FirstName",sponsor.FirstName);
                Sponsor s=_sponsors.Find(s=>s.Id==sponsor.Id).FirstOrDefault();
                _users.UpdateOne(Builders<User>.Filter.Eq("Id",s.User.Id),update_2);
                result=_sponsors.UpdateOne(filter,update_1);
              }
               else if(
                sponsor.LastName!=null 
                && sponsor.FirstName!=null){
                var update_2=Builders<User>.Update.Set("LastName",sponsor.LastName).Set("FirstName",sponsor.FirstName);
                Sponsor s=_sponsors.Find(s=>s.Id==sponsor.Id).FirstOrDefault();
               result= _users.UpdateOne(Builders<User>.Filter.Eq("Id",s.User.Id),update_2);
               
              }
              
               return result;
            
             
         }
          public UpdateResult pickInterest (UpdateDto sponsor){
             UpdateResult result=null;
          
              var filter=Builders<Sponsor>.Filter.Eq("Id",sponsor.Id);
              Sponsor s=_sponsors.Find(s=>s.Id==sponsor.Id).FirstOrDefault();
              if(s.Interests==null){
                    var update=Builders<Sponsor>.Update.Set("Interests",sponsor.Interests);
                    result=_sponsors.UpdateOne(filter,update);
              }
              else{
                  List<string>list=s.Interests;
                  sponsor.Interests.ForEach(interest=>list.Add(interest));
                   var update=Builders<Sponsor>.Update.Set("Interests",list);
                    result=_sponsors.UpdateOne(filter,update);
              }
             
              
              
               return result;
            
             
         }
        public List<Sponsor> ShowAllSponsors()
        {
           
             var query=from s in _sponsors.AsQueryable()
                    join u in _users.AsQueryable() on s.User.Id equals u.Id
                    select 
                    new Sponsor(){
                        Id=s.Id,
                        Entreprise=s.Entreprise,
                        Interests=s.Interests,
                        User=u
                    };
            
           
           
            
            return query.ToList();
        }
       

        Sponsor ISponsorRepository.FindSponsorProfile(string id)
        {
            Sponsor resultat=null;
              
                 var query=from s in _sponsors.AsQueryable().Where(Sponsor=> Sponsor.Id==id) 
                    join u in _users.AsQueryable() on s.User.Id equals u.Id
                    select 
                    new Sponsor(){
                        Id=s.Id,
                        Entreprise=s.Entreprise,
                        Interests=s.Interests,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            
           
           
            
            return resultat;
        }
         
       
       
    }
     
}