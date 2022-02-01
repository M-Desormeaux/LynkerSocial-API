using System;

namespace LynkerSocial_API.Models
{
    public class Community
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}