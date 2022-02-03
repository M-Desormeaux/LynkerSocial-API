using System;
using System.Collections.Generic;

namespace LynkerSocial_API.Models
{
    public class Community
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public List<Post> Posts { get; set; }
    }
}