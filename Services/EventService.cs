using System;
using System.Collections.Generic;
using clubyApi.Models;
using clubyApi.Repositories;
using ClubyBackend.Models;

namespace clubyApi.Services
{
    public class EventService : IEventService
    {
        
        private readonly IEventRepository _rep;
        public EventService(IEventRepository repo){
            _rep=repo;
        }
        public Tuple<Event,int> CreateEvent(EventDto  e)
        {
            return _rep.CreateEvent(e);
        }

        public List<Event> FindEventByClub(string club)
        {
           return _rep.FindEventByClub(club);
        }

        public List<Event> FindEventByDate(string date)
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

        public Event DeleteEvent(string id)
        {
            return _rep.DeleteEvent(id);
        }

        public Event FindEventById(string id)
        {
            return _rep.FindEventById(id);
        }
       

        public int DeleteUserParticipation(PartModel partModel)
        {
            return _rep.DeleteUserParticipation(partModel);
        }

        public int AddUserParticipation(string Eventid, string u)
        {
             return _rep.AddUserParticipation(Eventid,u);
        }

        public List<Participate> FindEventByUserParticipation(string u)
        {
            return _rep.FindEventByUserParticipation(u);
        }
        public List<Participate> ListEventPart(string id){
        return _rep.ListEventPart(id);
        }

        
    }
}