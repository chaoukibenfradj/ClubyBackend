using clubyApi.Models;

namespace clubyApi.Repositories
{
    public interface IUserRepository
    {
        User Authentificate(Authentification user);
        User Register(User user);
        User FindUserByEmail(string email);
    }
}