using DotNetBlog.Models;

namespace DotNetBlog.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; } = null!;

        /**
         * Is this really the best way to do this?
         * 
         * https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx
         * https://stackoverflow.com/a/47979168
         */
        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var Entries = ChangeTracker.Entries()
                .Where(E => E.Entity is BaseModel && (E.State == EntityState.Added || E.State == EntityState.Modified))
                .ToList();

            Entries.ForEach(E =>
            {
                var now = DateTime.UtcNow;

                E.Property("UpdatedDate").CurrentValue = now;

                if (E.State == EntityState.Added)
                {
                    E.Property("CreatedDate").CurrentValue = now;
                }
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
