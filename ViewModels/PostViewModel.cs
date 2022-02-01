using System.ComponentModel.DataAnnotations;
using LynkerSocial_API.Models;

namespace LynkerSocial_API.ViewModels
{
    public class PostViewModel
    {
        [Required]
        public User User { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}