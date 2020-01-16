using System;
using System.Collections.Generic;
using clubyApi.Models;
using ClubyBackend.Models;
using MongoDB.Driver;

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
        Event DeleteEvent(string id);
       Event FindEventById(string id);
       
       UpdateResult updatEvent(EventDto eventDto);
        
       public int DeleteUserParticipation(PartModel partModel);
       int AddUserParticipation(string Eventid,string u);
       List<Participate> FindEventByUserParticipation(string u);
       void ModifyEventNumberParticipat(string id , int number);
        List<Participate> ListEventPart(string id);
    }
}