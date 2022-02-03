using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynkerSocial_API.Models
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("CommunityId")]
        public Community Community { get; set; }
        public Guid CommunityId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }
    }
}