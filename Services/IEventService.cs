using System;
using System.Collections.Generic;
using clubyApi.Models;

namespace clubyApi.Services
{
    public interface IEventService
    {
        Event CreateEvent(Event e);
       List<Event>ShowAllEvents();
       List<Event>FindEventByDate(string date);
       List<Event>FindEventByDomain(string domain);
       List<Event>FindEventByClub(string club);
       List<Event>FindEventByInstitute(string institute);
    }
}