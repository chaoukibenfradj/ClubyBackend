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
       public Event DeleteEvent(string id);
       Event FindEventById(string id);


       public int DeleteUserParticipation(string Eventid, string Userid);
       int AddUserParticipation(string Eventid,string userId);
       List<Event> FindEventByUserParticipation(string userId);
       void ModifyEventNumberParticipat(Event e);
       public List<Participate> ListEventPart(string id);
    }
}