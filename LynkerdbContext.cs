
using LynkerSocial_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LynkerSocial_API
{
    public class LynkerdbContext : DbContext
    {
        public LynkerdbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}