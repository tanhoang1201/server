using Microsoft.EntityFrameworkCore;
using server.Context;

namespace server.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Blog> Blogs { get; set; }

    }
}