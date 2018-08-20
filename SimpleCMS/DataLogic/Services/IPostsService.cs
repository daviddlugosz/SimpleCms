using DataDomain.DbEntities;
using System.Collections.Generic;

namespace DataLogic.Services
{
    public interface IPostsService
    {
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> ListAllPosts();
        IEnumerable<Post> LoadNextPosts(int loadedItems, int itemsCount);
        Post GetPost(int id);
        void Delete(int id);
        void Update(int id, Post post);
        Post Create(Post post, string userName);
        void DeletePostsByAuthor(string userName);
        IEnumerable<Post> ListPostsByAuthor(string userName);
    }
}
