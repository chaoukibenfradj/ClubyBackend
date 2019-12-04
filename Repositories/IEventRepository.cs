using System;
using System.Collections.Generic;
using clubyApi.Models;

namespace clubyApi.Repositories
{
    public interface IEventRepository
    {
       Tuple<Event,int> CreateEvent(Event e);
       List<Event>ShowAllEvents();
       List<Event>FindEventByDate(string date);
       List<Event>FindEventByDomain(string domain);
       List<Event>FindEventByClub(string club);
       List<Event>FindEventByInstitute(string institute);




    }
}