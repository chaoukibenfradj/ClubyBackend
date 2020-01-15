using System;
using System.Collections.Generic;
using System.Linq;
using clubyApi.Models;
using ClubyBackend.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace clubyApi.Repositories
{
 public class EventRepository : IEventRepository
    {
        private readonly IMongoCollection<Event> _events;
         private readonly IMongoCollection<Student> _students;
        private readonly IMongoCollection<Institute> _institutes;
        private readonly IMongoCollection<Club> _clubs;
        private readonly IMongoCollection<User> _users;

        private readonly IMongoCollection<Domain> _domains;

        public EventRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _events = database.GetCollection<Event>(settings.EventCollectionName);
             _students = database.GetCollection<Student>(settings.StudentCollectionName); 
            _institutes = database.GetCollection<Institute>(settings.InstituteCollectionName); 
            _domains=database.GetCollection<Domain>(settings.DomainCollectionName);
            _clubs=database.GetCollection<Club>(settings.ClubCollectionName);
            _users=database.GetCollection<User>(settings.UserCollectionName);
        }

        
        public Tuple<Event,int> CreateEvent(EventDto e)
        {
            List<Event> events=FindEventByDate(e.BeginDate);
            e.CreationDate=DateTime.Today.ToString("dd-MM-yyyy hh:mm:ss");
            Event added=new Event(e);
            _events.InsertOne(added);
            return new Tuple<Event,int>(added,events.Count);
        }

        public List<Event> FindEventByClub(string club)
        {
                    
                    var query=from e in _events.AsQueryable().Where(Event => Event.Club.Id==club) 
                    join u in _clubs.AsQueryable() on e.Club.Id equals u.Id
                    join d in _domains.AsQueryable() on e.Domain.Id equals d.Id   
                    join inst in _institutes.AsQueryable() on e.Institute.Id equals inst.Id                
                    select 
                    new Event(){
                        Name=e.Name,
                        price=e.price,
                        Location=e.Location,
                        Photo=e.Photo,
                        Domain=d,
                        Description=e.Description,
                        BeginDate=e.BeginDate,
                        EndDate=e.EndDate,
                        Institute=inst,
                        Club=u,
                        NumberParticipation=e.NumberParticipation
                       
                    };
                   
           
            
            return query.ToList();

        }

        public List<Event> FindEventByDate(string date)
        {
              
                    var query=from e in _events.AsQueryable().Where(Event => Event.BeginDate==date) 
                    join u in _clubs.AsQueryable() on e.Club.Id equals u.Id       
                    join d in _domains.AsQueryable() on e.Domain.Id equals d.Id   
                    join inst in _institutes.AsQueryable() on e.Institute.Id equals inst.Id                
                    select 
                    new Event(){
                        Name=e.Name,
                        price=e.price,
                        Location=e.Location,
                        Photo=e.Photo,
                        Domain=d,
                        Description=e.Description,
                        BeginDate=e.BeginDate,
                        EndDate=e.EndDate,
                        Institute=inst,
                        Club=u,
                        NumberParticipation=e.NumberParticipation
                       
                    };
                   
           
            
            return query.ToList();
        }

        public List<Event> FindEventByDomain(string domain)
        {
                var query=from e in _events.AsQueryable().Where(Event => Event.Domain.Id==domain) 
                    join u in _clubs.AsQueryable() on e.Club.Id equals u.Id       
                    join d in _domains.AsQueryable() on e.Domain.Id equals d.Id   
                    join inst in _institutes.AsQueryable() on e.Institute.Id equals inst.Id                
                    select 
                    new Event(){
                        Name=e.Name,
                        price=e.price,
                        Location=e.Location,
                        Photo=e.Photo,
                        Domain=d,
                        Description=e.Description,
                        BeginDate=e.BeginDate,
                        EndDate=e.EndDate,
                        Institute=inst,
                        Club=u,
                        NumberParticipation=e.NumberParticipation
                       
                    };
                   
           
            
            return query.ToList();
        }

        public List<Event> FindEventByInstitute(string institute)
        {
              var query=from e in _events.AsQueryable().Where(Event => Event.Institute.Id==institute) 
                    join u in _clubs.AsQueryable() on e.Club.Id equals u.Id       
                    join d in _domains.AsQueryable() on e.Domain.Id equals d.Id   
                    join inst in _institutes.AsQueryable() on e.Institute.Id equals inst.Id                
                    select 
                    new Event(){
                        Name=e.Name,
                        price=e.price,
                        Location=e.Location,
                        Photo=e.Photo,
                        Domain=d,
                        Description=e.Description,
                        BeginDate=e.BeginDate,
                        EndDate=e.EndDate,
                        Institute=inst,
                        Club=u,
                        NumberParticipation=e.NumberParticipation
                       
                    };
                   
           
            
            return query.ToList();
        }

        public List<Event> ShowAllEvents()
        {
          
              var query=from e in _events.AsQueryable()
                    join u in _clubs.AsQueryable() on e.Club.Id equals u.Id       
                    join d in _domains.AsQueryable() on e.Domain.Id equals d.Id   
                    join inst in _institutes.AsQueryable() on e.Institute.Id equals inst.Id                
                    select 
                    new Event(){
                        Name=e.Name,
                        price=e.price,
                        Location=e.Location,
                        Photo=e.Photo,
                        Domain=d,
                        Description=e.Description,
                        BeginDate=e.BeginDate,
                        EndDate=e.EndDate,
                        Institute=inst,
                        Club=u,
                        NumberParticipation=e.NumberParticipation
                       
                    };
                   
           
            
            return query.ToList();
        }

        public Event DeleteEvent(string id)
        {
            return _events.FindOneAndDelete(s=>s.Id==id);
        }

        public Event FindEventById(string id){

        return _events.Find(e =>  e.Id==id).FirstOrDefault();
        }
       

        public List<Participate> ListEventPart(string id){
            Event e = FindEventById(id);
            if (e == null)
            {
                return null;
            }else{
            
                return e.ListParticipation;
            }
                  
              
        }

        
        public int DeleteUserParticipation(string Eventid,User u)
        {

            Event e = FindEventById(Eventid);
            if (e == null)
            {
                return 1;
            }
            else
            {
                
                 Participate userp = e.ListParticipation.Find(x => x.user.Id == u.Id);
                if (userp != null){
                    e.ListParticipation.Remove(userp);
                    e.NumberParticipation+=1;
                    ModifyEventNumberParticipat(e);
                    return 0;
                }else{
                    return 2;
                }
            }

        }

        public int AddUserParticipation(string Eventid, User u)
        {

            Event e = FindEventById(Eventid);
            if (e == null)
            {
                return 1;
            }
            else
            {
                if(e.NumberParticipation==0){
                return 2;

                }else{

                Participate userp = e.ListParticipation.Find(x => x.user.Id == u.Id);
                if (userp == null){
                    string dateAdd=DateTime.Today.ToString("dd-MM-yyyy hh:mm:ss");
                    Participate p =new Participate(u,dateAdd);
                    e.ListParticipation.Add(new Participate (p));
                    e.NumberParticipation=e.NumberParticipation-1;
                     ModifyEventNumberParticipat(e);
                    return 0;
                }else{
                    return 3;
                }
             }

            }


        }

        public List<Event> FindEventByUserParticipation(User u)
        {
            
            return _events.Find<Event>(e => 
            e.ListParticipation.Exists(y=>
            y.user==u)
            
            
            ).ToList<Event>();

        }

        public void ModifyEventNumberParticipat(Event e)
        {
            var filter=Builders<Event>.Filter.Eq(d=>d.Id,e.Id);

            var update=Builders<Event>.Update.Set("Number",e.NumberParticipation).Set("ListParticipation",e.ListParticipation);
             _events.FindOneAndUpdate(filter,update);
        }

   
    }
}