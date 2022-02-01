using System.Threading.Tasks;
using LynkerSocial_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using LynkerSocial_API.Models;

namespace LynkerSocial_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly LynkerdbContext _db;

        public PostController(LynkerdbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel postModel)
        {
            Response response = new Response()
            {
                Success = true,
                Message = "Post Successful."
            };

            Post post = new Post()
            {
                // User?

                User = postModel.User,
                Title = postModel.Title,
                Body = postModel.Body
            }
            return Ok();
        }
    }
}