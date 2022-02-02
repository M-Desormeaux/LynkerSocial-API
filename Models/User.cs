using System;

namespace LynkerSocial_API.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Score { get; set; }
    }
}