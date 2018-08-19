using DataDomain.DbEntities;
using System.Collections.Generic;

namespace DataLogic.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        User CreateAdminUser(User user, string password);
        User PromoteToAuthor(User user);
        void Update(User user, string password = null);
        void Delete(int id);
        void CreateRoles();
    }
}
