using System;
using System.Collections.Generic;
using clubyApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
 public class EventRepository : IEventRepository
    {
        private readonly IMongoCollection<Event> _events;
        
        public EventRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _events = database.GetCollection<Event>(settings.EventCollectionName); 

        }

        
        public Tuple<Event,int> CreateEvent(Event e)
        {
            List<Event> events=FindEventByDate(e.BeginDate);
            e.CreationDate=DateTime.Today.ToString("dd-MM-yyyy hh:mm:ss");
            _events.InsertOne(new Event(e));
            return new Tuple<Event,int>(e,events.Count);
        }

        public List<Event> FindEventByClub(string club)
        {
            return _events.Find<Event>(e => e.Club.Equals(club)).ToList<Event>();

        }

        public List<Event> FindEventByDate(string date)
        {
            return _events.Find<Event>(e => e.BeginDate == date).ToList<Event>();
        }

        public List<Event> FindEventByDomain(string domain)
        {
            return _events.Find<Event>(e => e.Domain.Equals(domain)).ToList<Event>();
        }

        public List<Event> FindEventByInstitute(string institute)
        {
            return _events.Find<Event>(e => e.Institute.Equals(institute)).ToList<Event>();
        }

        public List<Event> ShowAllEvents()
        {
            int limit=10;
            return _events.Find<Event>(new FilterDefinitionBuilder<Event>().Empty).Limit(limit).ToList<Event>();
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