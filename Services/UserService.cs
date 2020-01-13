using System.Collections.Generic;
using clubyApi.Models;
using clubyApi.Repositories;
using ClubyBackend.Models;

namespace clubyApi.Services
{
    public class UserService:IUserService
    {   
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo){
            _repo=repo;

        }

        public User Authentificate(Authentification user)
        {
           return _repo.Authentificate(user);
        }

        public User FindUserByEmail(string email)
        {
            return _repo.FindUserByEmail(email);
        }

        public User Register(User user)
        {
            return _repo.Register(user);
        }
         public List<Email> FindEmailBySenderId(string id){
             return _repo.FindEmailBySenderId(id);
         }
        public List<Email> FindEmailByReceiverId(string id){
            return _repo.FindEmailByReceiverId(id);
        }
       public Email SendEmail(Email email,string sender,string receiver){
           return _repo.SendEmail(email,sender,receiver);
       }

        public User FindUserById(string id)
        {
            return _repo.FindUserById(id);
        }
    }
}