using System.Threading.Tasks;
using LynkerSocial_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using LynkerSocial_API.Models;
using System.Threading;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPost(Guid postId)
        {
            var post = await _db.Posts.FindAsync(postId);

            if (post == null)
            {
                return NotFound(ApiResponse<Post>.Failure("Post not found"));
            }

            return Ok(ApiResponse<Post>.Success(post));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var postList = await _db.Posts.ToListAsync();

            return Ok(ApiResponse<IEnumerable<Post>>.Success(postList));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel postModel, CancellationToken cancelToken)
        {

            // @TODO: Add verification that user exists!

            Post post = new()
            {
                UserId = postModel.UserId,
                Title = postModel.Title,
                Body = postModel.Body
            };

            _db.Posts.Add(post);
            await _db.SaveChangesAsync(cancelToken);

            return Ok(ApiResponse<Guid>.Success(post.Id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(Guid postId, CancellationToken cancelToken)
        {

            Post post = await _db.Posts.FindAsync(postId);

            if (post is null)
            {
                return NotFound(ApiResponse<Post>.Failure("Post not found"));
            }

            _db.Posts.Remove(post);
            await _db.SaveChangesAsync(cancelToken);

            return Ok();
        }
    }
}