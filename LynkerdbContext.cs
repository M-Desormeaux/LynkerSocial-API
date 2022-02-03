
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasOne(x => x.User).WithOne().OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<Post>()
            // .HasOne(p => p.Community)
            // .WithMany(p => p.Posts)
            // .UsingEntity<Post>(
            //     j => j
            //         .HasOne(pt => pt.Tag)
            //         .WithMany(t => t.PostTags)
            //         .HasForeignKey(pt => pt.TagId)
            //         .OnDelete(DeleteBehavior.Restrict),
            //     j => j
            //         .HasOne(pt => pt.Post)
            //         .WithMany(p => p.PostTags)
            //         .HasForeignKey(pt => pt.PostId)
            //         .OnDelete(DeleteBehavior.Restrict),
            //     j =>
            //     {
            //         j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            //         j.HasKey(t => new { t.PostId, t.TagId });
            //     });
        }
    }
}