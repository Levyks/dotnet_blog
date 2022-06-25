using DotNetBlog.Models;

namespace DotNetBlog.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; } = null!;
    }
}
