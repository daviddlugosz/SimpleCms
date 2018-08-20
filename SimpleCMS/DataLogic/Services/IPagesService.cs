using DataDomain.DbEntities;
using System.Collections.Generic;

namespace DataLogic.Services
{
    public interface IPagesService
    {
        IEnumerable<Page> GetAllFullPages();
        IEnumerable<Page> ListAllPages();
        Page GetFullPage(int id);
        void Delete(int id);
        void Update(int id, Page page);
        Page Create(Page page);
    }
}
