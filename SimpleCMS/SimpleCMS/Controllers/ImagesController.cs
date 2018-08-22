using DataDomain.DbEntities;
using DataLogic.Helpers;
using DataLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCms.ViewModels.Images;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCms.Controllers
{
    [Authorize(Roles = "admin, author")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ImagesController : ControllerBase
    {
        public readonly IImageObjectsService _imageObjectsService;

        public ImagesController(IImageObjectsService imageObjectsService)
        {
            _imageObjectsService = imageObjectsService;
        }

        [HttpGet]
        public List<string> GetAllImagePaths()
        {
            return _imageObjectsService.GetAllImagePaths().ToList();
        }

        [HttpPost]
        public FullImageObjectViewModel Create(FullImageObjectViewModel image)
        {
            var result = new FullImageObjectViewModel();

            var createdEntity = _imageObjectsService.UploadImage(image.Content, image.Name, image.Description, HttpContext.User.Identity.Name);
            if (createdEntity != null)
            {
                result = GenericMapper.MapObject<FullImageObjectViewModel>(createdEntity);
            }

            return result;
        }
    }
}