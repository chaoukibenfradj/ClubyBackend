using System;
using System.Collections.Generic;
using clubyApi.Models;

namespace clubyApi.Repositories
{
    public class EventRepository : IEventRepository
    {

        
        public Event CreateEvent(Event e)
        {
            throw new System.NotImplementedException();
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