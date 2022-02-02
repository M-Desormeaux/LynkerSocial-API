using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LynkerSocial_API.ViewModels
{
    public class CommunityViewModel
    {
        [Required]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}