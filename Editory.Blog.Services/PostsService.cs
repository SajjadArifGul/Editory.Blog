using Editory.Blog.Data;
using Editory.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editory.Blog.Services
{
    public class PostsService
    {
        #region Define as Singleton
        private static PostsService _Instance;

        public static PostsService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PostsService();
                }

                return (_Instance);
            }
        }

        private PostsService()
        {
        }
        #endregion

        public List<Post> SearchPosts(int? postStatus, string searchTerm, int pageNo = 1, int recordSize = 10)
        {
            var context = new AppDataContext();

            var posts = context.Posts.AsQueryable();

            if (postStatus.HasValue)
            {
                posts = posts.Where(post => post.Status == postStatus.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                posts = posts.Where(post=>post.Title.Contains(searchTerm));
            }

            posts = posts.OrderBy(post=>post.ID).Skip((pageNo - 1) * recordSize).Take(recordSize);

            return posts.ToList();
        }

        public int SearchPostsCount(int? postStatus, string searchTerm)
        {
            var context = new AppDataContext();

            var posts = context.Posts.AsQueryable();

            if (postStatus.HasValue)
            {
                posts = posts.Where(post => post.Status == postStatus.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                posts = posts.Where(post => post.Title.Contains(searchTerm));
            }

            return posts.Count();
        }

        public Post GetPostByID(int ID)
        {
            AppDataContext context = new AppDataContext();

            return context.Posts.Find(ID);
        }

    }
}
