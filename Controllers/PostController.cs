using System.Threading.Tasks;
using LynkerSocial_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using LynkerSocial_API.Models;
using System.Threading;
using System;

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
        public async Task<IActionResult> CreatePost(PostViewModel postModel, CancellationToken cancelToken)
        {
            Response response = new Response()
            {
                Success = true,
                Message = "Post Successful."
            };

            // @TODO: Add verification that user exists!

            Post post = new Post()
            {
                UserId = postModel.UserId,
                Title = postModel.Title,
                Body = postModel.Body
            };

            _db.Posts.Add(post);
            await _db.SaveChangesAsync(cancelToken);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(Guid postId, CancellationToken cancelToken)
        {
            Response response = new Response();

            Post post = await _db.Posts.FindAsync(postId);

            if (post is null)
            {
                response.Message = "Post not found";
                return NotFound(response);
            }

            response.Success = true;
            response.Message = $"{post.Title} deleted.";

            _db.Posts.Remove(post);
            await _db.SaveChangesAsync(cancelToken);

            return Ok(response);
        }
    }
}