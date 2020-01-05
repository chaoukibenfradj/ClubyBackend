using System;
using System.Collections.Generic;
using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Services
{
    public interface IEventService
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
       public List<Participate> ListEventPart(string id);
    }
}