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
        private readonly IMongoCollection<Participate> _participation;

        public EventRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _events = database.GetCollection<Event>(settings.EventCollectionName);
             _students = database.GetCollection<Student>(settings.StudentCollectionName); 
            _institutes = database.GetCollection<Institute>(settings.InstituteCollectionName); 
            _domains=database.GetCollection<Domain>(settings.DomainCollectionName);
            _clubs=database.GetCollection<Club>(settings.ClubCollectionName);
            _users=database.GetCollection<User>(settings.UserCollectionName);
            _participation=database.GetCollection<Participate>(settings.ParticipationCollectionName);
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
                         Id=e.Id,
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
                         Id=e.Id,
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
                         Id=e.Id,
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
                         Id=e.Id,
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
                        Id=e.Id,
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

         var query=from e in _events.AsQueryable().Where(Event=> Event.Id==id)
                    join u in _clubs.AsQueryable() on e.Club.Id equals u.Id       
                    join d in _domains.AsQueryable() on e.Domain.Id equals d.Id   
                    join inst in _institutes.AsQueryable() on e.Institute.Id equals inst.Id                
                    select 
                    new Event(){
                         Id=e.Id,
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
                   
           
            
            return query.FirstOrDefault();
        }
       

        public List<Participate> ListEventPart(string id){
           
                  List<Participate>list=new List<Participate>();
                  var query=from e in _participation.AsQueryable().Where(Participate=> Participate.Event.Id==id)
                    join s in _students.AsQueryable() on e.user.Id equals s.Id  
                    select 
                    new Participate( ){
                       Id=e.Id,
                       user=s,
                       Event=e.Event,
                       DateParticipate=e.DateParticipate,
                       Accepted=e.Accepted
                       
                    };
                    query.ToList().ForEach(Participate=>{
                        Student student=findInfo(Participate.user.Id);
                        list.Add(new Participate(student,student.user,Participate.DateParticipate, Participate.Accepted,Participate.Event));

                    });
                   
            
            return list;
              
        }
         public  Student findInfo(string id){
            Student resultat=null;
                    if(_students.AsQueryable().Where(Student=> Student.Id==id).FirstOrDefault().Institute.Id==null){
                    var query=from s in _students.AsQueryable().Where(Student=> Student.Id==id) 
                    join u in _users.AsQueryable() on s.user.Id equals u.Id                
                    select 
                    new Student(){
                        Id=s.Id,
                        Institute=s.Institute,
                        Photo=s.Photo,
                        user=u
                    };
                    resultat=query.FirstOrDefault();
           
            }
            else{
                 var query=from s in _students.AsQueryable().Where(Student=> Student.Id==id) 
                    join u in _users.AsQueryable() on s.user.Id equals u.Id
                    join inst in _institutes.AsQueryable() on s.Institute.Id equals inst.Id 
                    select 
                    new Student(){
                        Id=s.Id,
                        Institute=inst,
                        Photo=s.Photo,
                        user=u
                    };
                    resultat=query.FirstOrDefault();
            }
           
           
            
            return resultat;
        }

        
        public int DeleteUserParticipation(PartModel partModel)
        {

           
                Participate userp=_participation.Find<Participate>(Participate=>Participate.user.Id==partModel.userId 
                && Participate.Event.Id==partModel.eventId).FirstOrDefault();

                
                if (userp != null){
                   _participation.FindOneAndDelete(Participate=>Participate.user.Id==partModel.userId 
                    && Participate.Event.Id==partModel.eventId);
                    Event e= _events.Find<Event>(Event=>Event.Id==partModel.eventId).FirstOrDefault();
                    int number=e.NumberParticipation+1;
                     ModifyEventNumberParticipat(userp.Event.Id,number);
                   
                    return 0;
                }
                else{
                    return 1;
                }
            

        }

        public int AddUserParticipation(string Eventid, string u)
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

                }
                else
                {
                Participate userp=_participation.Find<Participate>(Participate=>Participate.user.Id==u && Participate.Event.Id==Eventid).FirstOrDefault();
                

                if (userp == null){
                    string dateAdd=DateTime.Today.ToString("dd-MM-yyyy hh:mm:ss");
                    Participate p =new Participate(Eventid,u,dateAdd);
                    
                    _participation.InsertOne(p);
                   
                    int number=e.NumberParticipation-1;
                     ModifyEventNumberParticipat(Eventid,number);
                    return 0;
                }else{
                    return 3;
                }
             }

            }


        }

        public List<Participate> FindEventByUserParticipation(string u)
        {
            
             var query=from e in _participation.AsQueryable().Where(Participate=>Participate.user.Id==u)
                    join ev in _events.AsQueryable() on e.Event.Id equals ev.Id                
                    select 
                    new Participate(){
                       Event=ev,
                       Accepted=e.Accepted,
                       DateParticipate=e.DateParticipate

                       
                    };
                   
           
            
            return query.ToList();

        }

        public void ModifyEventNumberParticipat(string id , int number)
        {
            var filter=Builders<Event>.Filter.Eq(d=>d.Id,id);

            var update=Builders<Event>.Update.Set("Number",number);
             _events.FindOneAndUpdate(filter,update);
        }

        
    }
}