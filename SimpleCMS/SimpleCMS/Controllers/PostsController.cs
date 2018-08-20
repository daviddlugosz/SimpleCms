using DataDomain.DbEntities;
using DataLogic.Helpers;
using DataLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCms.ViewModels.Posts;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCms.Controllers
{
    [Authorize(Roles = "admin, author")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public List<PostListItemViewModel> ListAllPosts()
        {
            var result = new List<PostListItemViewModel>();

            var posts = _postsService.ListAllPosts();
            return posts.Count() == 0 ? null : GenericMapper.MapListOfObjects<PostListItemViewModel>(posts).ToList();
        }

        [HttpGet]
        [AllowAnonymous]
        public List<PostListItemViewModel> LoadNextPosts(int loadedItems, int itemsCount)
        {
            var result = new List<PostListItemViewModel>();

            var posts = _postsService.LoadNextPosts(loadedItems, itemsCount);
            return posts.Count() == 0 ? null : GenericMapper.MapListOfObjects<PostListItemViewModel>(posts).ToList();
        }

        [HttpGet]
        [AllowAnonymous]
        public List<PostListItemViewModel> ListPostsByAuthor(string userName)
        {
            var result = new List<PostListItemViewModel>();

            var posts = _postsService.ListPostsByAuthor(userName);
            return posts.Count() == 0 ? null : GenericMapper.MapListOfObjects<PostListItemViewModel>(posts).ToList();
        }

        [HttpPost]
        public FullPostViewModel Create(FullPostViewModel page)
        {
            var result = new FullPostViewModel();

            var newEntity = GenericMapper.MapObject<Post>(page);
            var createdEntity = _postsService.Create(newEntity, HttpContext.User.Identity.Name);
            if (createdEntity != null)
            {
                result = GenericMapper.MapObject<FullPostViewModel>(createdEntity);
            }

            return result;
        }

        [HttpPut]
        public void Update(int id, FullPostViewModel page)
        {
            var updatedEntity = GenericMapper.MapObject<Post>(page);
            _postsService.Update(id, updatedEntity);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _postsService.Delete(id);
        }

        [HttpDelete]
        public void DeletePostsByAuthor(string userName)
        {
            _postsService.DeletePostsByAuthor(userName);
        }
    }
}