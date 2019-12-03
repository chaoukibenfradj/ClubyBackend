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

        
        public Event CreateEvent(Event e)
        {
            List<Event> events=FindEventByDate(e.BeginDate);
            Event result=null;
            if(events.Count==0){
                result=e;
                _events.InsertOne(new Event(e));

            }

            return result;
        }

        public List<Event> FindEventByClub(string club)
        {
            return _events.Find<Event>(e => e.Club.Id.Equals(club)).ToList<Event>();

        }

        public List<Event> FindEventByDate(DateTime date)
        {
            return _events.Find<Event>(e => e.BeginDate == date).ToList<Event>();
        }

        public List<Event> FindEventByDomain(string domain)
        {
            return _events.Find<Event>(e => e.Domain.Id.Equals(domain)).ToList<Event>();
        }

        public List<Event> FindEventByInstitute(string institute)
        {
            return _events.Find<Event>(e => e.Institute.Id.Equals(institute)).ToList<Event>();
        }

        public List<Event> ShowAllEvents()
        {
            int limit=10;
            return _events.Find<Event>(new FilterDefinitionBuilder<Event>().Empty).Limit(limit).ToList<Event>();
        }
    }
}