using clubyApi.Models;
using clubyApi.Repositories;

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
    }
}