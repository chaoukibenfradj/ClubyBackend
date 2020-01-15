using System;
using System.Collections.Generic;
using clubyApi.Models;
using ClubyBackend.Models;

namespace clubyApi.Repositories
{
    public interface IEventRepository
    {
       Tuple<Event,int> CreateEvent(EventDto e);
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
       void ModifyEventNumberParticipat(string id , int number);
       public List<Participate> ListEventPart(string id);
    }
}