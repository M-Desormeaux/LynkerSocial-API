using System;

namespace LynkerSocial_API.Models
{
    public class Post
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }
    }
}