using System;
using System.ComponentModel.DataAnnotations;

namespace LynkerSocial_API.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
    }
}