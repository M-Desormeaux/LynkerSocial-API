using System;
using System.ComponentModel.DataAnnotations;
using LynkerSocial_API.Models;

namespace LynkerSocial_API.ViewModels
{
    public class PostViewModel
    {
        [Required]
        public Guid UserId { get; set; }
        public Guid CommunityId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }
}