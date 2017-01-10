using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Satoskar.Models;
using Satoskar.Database;
using Satoskar.Database.Repositories;

namespace UnitTestProject
{
    [TestClass]
    public class PostsRepositoryInitegrationTests
    {
        private const string Frameworks = "Frameworks";

        [TestMethod]
        public void QueryPostsInFrameworks()
        {
            using (var dataContext = new BlogContext())
            {
                var postRepository = new Repository<Post>(dataContext);

                IEnumerable<Post> posts = postRepository
                    .GetAll()
                    .Where(p => p.Blog.Name == Frameworks);

                foreach (Post post in posts)
                {
                    Assert.AreEqual(Frameworks, post.Blog.Name);
                    Debug.WriteLine(post.Title);
                }
            }
        }

        [TestMethod]
        public void SearchForPostsInFrameworks()
        {
            using (var dataContext = new BlogContext())
            {
                var postRepository = new Repository<Post>(dataContext);

                IEnumerable<Post> posts = postRepository
                    .SearchFor(p => p.Blog.Name == Frameworks);

                foreach (Post post in posts)
                {
                    Assert.AreEqual(Frameworks, post.Blog.Name);
                    Debug.WriteLine(post.Title);
                }
            }
        }

        #region Init and Cleanup

        [TestInitialize]
        public void Init()
        {
            Cleanup();

            using (var dataContext = new BlogContext())
            {
                var frameworks = new Blog { Name = Frameworks };

                var p1 = new Post
                {
                    Blog = frameworks,
                    Title = "Singleton"
                };

                var p2 = new Post
                {
                    Blog = frameworks,
                    Title = "Stratgey"
                };

                dataContext.Posts.Add(p1);
                dataContext.Posts.Add(p2);
                dataContext.SaveChanges();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var dataContext = new BlogContext())
            {
                IQueryable<Post> posts = dataContext.Posts.Select(p => p);
                IQueryable<Blog> blogs = dataContext.Blogs.Select(b => b);

                foreach (Blog blog in blogs)
                {
                    dataContext.Blogs.Remove(blog);
                }

                foreach (Post post in posts)
                {
                    dataContext.Posts.Remove(post);
                }

                dataContext.SaveChanges();
            }
        }

        #endregion
    }
}
