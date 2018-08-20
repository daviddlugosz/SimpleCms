using DataDomain.DbEntities;
using DataLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCms.ViewModels.Pages;
using System.Collections.Generic;
using System.Linq;
using DataLogic.Helpers;

namespace SimpleCms.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PagesController : ControllerBase
    {
        public readonly IPagesService _pagesService;

        public PagesController(IPagesService pagesService)
        {
            _pagesService = pagesService;
        }

        [HttpGet]
        [AllowAnonymous]
        public List<PageListItemViewModel> ListAllPages()
        {
            var result = new List<FullPageViewModel>();

            var pages = _pagesService.ListAllPages();
            return pages.Count() == 0 ? null : GenericMapper.MapListOfObjects<PageListItemViewModel>(pages).ToList();
        }

        [HttpPost]
        public FullPageViewModel Create(FullPageViewModel page)
        {
            var result = new FullPageViewModel();

            var newEntity = GenericMapper.MapObject<Page>(page);
            var createdEntity = _pagesService.Create(newEntity);
            if (createdEntity != null)
            {
                result = GenericMapper.MapObject<FullPageViewModel>(createdEntity);
            }

            return result;
        }

        [HttpPut]
        public void Update(int id, FullPageViewModel page)
        {
            var updatedEntity = GenericMapper.MapObject<Page>(page);
            _pagesService.Update(id, updatedEntity);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _pagesService.Delete(id);
        }
    }
}