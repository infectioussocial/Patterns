using System.Data.Entity;
using Satoskar.Models;

namespace Satoskar.Database
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
