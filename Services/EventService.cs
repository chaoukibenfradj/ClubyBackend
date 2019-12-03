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
        public Event CreateEvent(Event e)
        {
            return _rep.CreateEvent(e);
        }

        public List<Event> FindEventByClub(string club)
        {
           return _rep.FindEventByClub(club);
        }

        public List<Event> FindEventByDate(DateTime date)
        {
            return _rep.FindEventByDate(date);
        }

        public List<Event> FindEventByDomain(string domain)
        {
            return _rep.FindEventByDomain(domain);
        }

        public List<Event> FindEventByInstitute(string institute)
        {
            return _rep.FindEventByInstitute(institute);
        }

        
        List<Event> IEventService.ShowAllEvents()
        {
            return _rep.ShowAllEvents();
        }
    }
}