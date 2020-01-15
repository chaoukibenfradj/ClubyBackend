using System;
using System.Collections.Generic;
using clubyApi.Models;
using ClubyBackend.Models;
using MongoDB.Driver;

namespace clubyApi.Services
{
     public interface IEventService
    {
       Tuple<Event,int> CreateEvent(EventDto  e);
       List<Event>ShowAllEvents();
       List<Event>FindEventByDate(string date);
       List<Event>FindEventByDomain(string domain);
       List<Event>FindEventByClub(string club);
       List<Event>FindEventByInstitute(string institute);
       public Event DeleteEvent(string id);

       Event FindEventById(string id);
      
       public int DeleteUserParticipation(PartModel partModel);
       int AddUserParticipation(string Eventid,string u);
       List<Participate> FindEventByUserParticipation(string u);
       public List<Participate> ListEventPart(string id);

    }
}