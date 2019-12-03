using System;
using System.Collections.Generic;
using clubyApi.Models;

namespace clubyApi.Repositories
{
    public interface IEventRepository
    {
       Event CreateEvent(Event e);
       List<Event>ShowAllEvents();
       List<Event>FindEventByDate(DateTime date);
       List<Event>FindEventByDomain(string domain);
       List<Event>FindEventByClub(string club);
       List<Event>FindEventByInstitute(string institute);




    }
}