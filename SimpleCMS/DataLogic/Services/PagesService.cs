using System.Collections.Generic;
using System.Linq;
using DataDomain.DbEntities;
using DataLogic.Helpers;

namespace DataLogic.Services
{
    public class PagesService : IPagesService
    {
        private readonly DataContext _context;

        public PagesService(DataContext context)
        {
            _context = context;
        }

        public Page Create(Page page)
        {
            if(string.IsNullOrWhiteSpace(page.Name))
                throw new AppException("Name is required");

            var sameNamePage = _context.Pages.FirstOrDefault(p => p.Name == page.Name);
            if(sameNamePage != null)
                throw new AppException($"There is already page with name {page.Name}!");

            _context.Pages.Add(page);
            _context.SaveChanges();

            return _context.Pages.FirstOrDefault(p => p.Name == page.Name);
        }

        public void Delete(int id)
        {
            var page = _context.Pages.FirstOrDefault(p => p.Id == id);
            if (page == null)
                throw new AppException("Page you are trying to delete cannot be found!");

            _context.Pages.Remove(page);
            _context.SaveChanges();
        }

        public IEnumerable<Page> GetAllFullPages()
        {
            return _context.Pages;
        }

        public Page GetFullPage(int id)
        {
            return _context.Pages.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Page> ListAllPages()
        {
            return _context.Pages.Select(p => new Page
            {
                Id = p.Id,
                Name = p.Name
            });
        }

        public void Update(int id, Page page)
        {
            var originalPage = _context.Pages.FirstOrDefault(p => p.Id == id);
            if (originalPage == null)
                throw new AppException("Page you are trying to delete cannot be found!");

            if (page.Name != originalPage.Name)
                originalPage.Name = page.Name;
            if (page.Content != originalPage.Content)
                originalPage.Content = page.Content;

            _context.SaveChanges();
        }
    }
}
