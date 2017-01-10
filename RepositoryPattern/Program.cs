using System;
using System.Collections.Generic;
using System.Linq;
using Satoskar.Database;
using Satoskar.Database.Repositories;
using Satoskar.Models;


namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dataContext = new BlogContext())
            {
                var postRepository = new Repository<Post>(dataContext);
                var blogRepository = new Repository<Blog>(dataContext);

                Blog blog = blogRepository
                    .SearchFor(b => b.Name.Equals("Frameworks"))
                    .Single();

                IEnumerable<Post> orderedPosts = postRepository
                    .GetAll()
                    .Where(b => b.Blog.Id.Equals(1))
                    .OrderBy(p => p.Title);

                Console.WriteLine("Blogs in {0} ", blog.Name);

                foreach (Post orderedPost in orderedPosts)
                {
                    Console.WriteLine(orderedPost.Title);
                }

                Console.ReadKey();
            }
        }
    }
}
