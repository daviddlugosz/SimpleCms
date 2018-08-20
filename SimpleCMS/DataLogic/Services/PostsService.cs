using System.Collections.Generic;
using System.Linq;
using DataDomain.DbEntities;
using DataLogic.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DataLogic.Services
{
    public class PostsService : IPostsService
    {
        private readonly DataContext _context;

        public PostsService(DataContext context)
        {
            _context = context;
        }

        public Post Create(Post post, string userName)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
                throw new AppException("Error retrieving logged in user!");
            else
                post.Author = user;

            if (string.IsNullOrWhiteSpace(post.Name))
                throw new AppException("Name is required");

            var sameNamePage = _context.Pages.FirstOrDefault(p => p.Name == post.Name);
            if (sameNamePage != null)
                throw new AppException($"There is already post with name {post.Name}!");

            _context.Posts.Add(post);
            _context.SaveChanges();

            return _context.Posts.FirstOrDefault(p => p.Name == post.Name);
        }

        public void Delete(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
                throw new AppException("Post you are trying to delete cannot be found!");

            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public void DeletePostsByAuthor(string userName)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
                throw new AppException($"User {userName} was not found!");

            var userPosts = _context.Posts.Where(p => p.Author == user);
            if (userPosts.Count() != 0)
                _context.Posts.RemoveRange(userPosts);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts.Include(p => p.Author);
        }

        public Post GetPost(int id)
        {
            return _context.Posts.Include(p => p.Author).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> ListPostsByAuthor(string userName)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
                throw new AppException("Error retrieving user!");

            return _context.Posts.Where(p => p.Author == user).Select(post => new Post
            {
                Name = post.Name,
                Description = post.Description,
                CoverImagePath = post.CoverImagePath
            });
        }

        public IEnumerable<Post> ListAllPosts()
        {
            return _context.Posts.Include(p => p.Author)
                .Select(post => new Post
            {
                Name = post.Name,
                Description = post.Description,
                CoverImagePath = post.CoverImagePath,
                Author = new User {
                    UserName = post.Author.UserName,
                    FirstName = post.Author.FirstName,
                    LastName = post.Author.LastName
                }
            });
        }

        public IEnumerable<Post> LoadNextPosts(int loadedItems, int itemsCount)
        {
            return _context.Posts
                .Skip(loadedItems)
                .Take(itemsCount).Select(post => new Post
                {
                    Name = post.Name,
                    Description = post.Description,
                    CoverImagePath = post.CoverImagePath,
                    Author = new User
                    {
                        UserName = post.Author.UserName,
                        FirstName = post.Author.FirstName,
                        LastName = post.Author.LastName
                    }
                });
        }

        public void Update(int id, Post post)
        {
            var originalPost = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (originalPost == null)
                throw new AppException("Post you are trying to delete cannot be found!");

            originalPost.Name = post.Name;
            originalPost.Description = post.Description;
            originalPost.CoverImagePath = post.CoverImagePath;
            originalPost.Content = post.Content;

            _context.SaveChanges();
        }
    }
}
