using System.Collections.Generic;
using clubyApi.Models;
using ClubyBackend.Models;

namespace clubyApi.Repositories
{
    public interface IUserRepository
    {
        User Authentificate(Authentification user);
        User Register(User user);
        User FindUserByEmail(string email);
        List<Email> FindEmailBySenderId(string id);
        List<Email> FindEmailByReceiverId(string id);
       EmailDto SendEmail(EmailDto email);

    }
}