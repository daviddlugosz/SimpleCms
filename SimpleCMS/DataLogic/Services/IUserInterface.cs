using DataDomain.DbEntities;
using System.Collections.Generic;

namespace DataLogic.Services
{
    public interface IUserService
    {
        User Authenticate(string userName, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByUserName(string userName);
        User Create(User user, string password);
        User CreateAdminUser(User user, string password);
        User PromoteToAuthor(User user);
        void Update(User user, string password = null);
        void Delete(int id);
        void CreateRoles();
    }
}
