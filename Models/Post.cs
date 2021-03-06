using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynkerSocial_API.Models
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public Guid CommunityId { get; set; }
        public Community Community { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }
    }
}