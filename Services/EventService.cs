using System;
using System.Collections.Generic;
using clubyApi.Models;
using clubyApi.Repositories;

namespace clubyApi.Services
{
    public class EventService : IEventService
    {
        
        private readonly IEventRepository _rep;
        public EventService(IEventRepository repo){
            _rep=repo;
        }
        public EventModel CreateEvent(EventModel e)
        {
            return _rep.CreateEvent(e);
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
            throw new NotImplementedException();
        }
    }
}