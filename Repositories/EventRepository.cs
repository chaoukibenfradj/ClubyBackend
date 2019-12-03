using System;
using System.Collections.Generic;
using clubyApi.Models;
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

        
        public EventModel CreateEvent(EventModel e)
        {
            List<Event> events=FindEventByDate(e.BeginDate);
            EventModel result=null;
            if(events.Count==0){
                result=e;
                _events.InsertOne(new Event(e));

            }

            return result;
        }

        public List<Event> FindEventByClub(string club)
        {
            throw new NotImplementedException();
        }

        public List<Event> FindEventByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Event> FindEventByDomain(string domain)
        {
            throw new NotImplementedException();
        }

        public List<Event> FindEventByInstitute(string institute)
        {
            throw new NotImplementedException();
        }

        public List<Event> ShowAllEvents()
        {
            throw new System.NotImplementedException();
        }
    }
}