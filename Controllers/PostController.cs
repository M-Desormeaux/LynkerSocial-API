using System.Threading.Tasks;
using LynkerSocial_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using LynkerSocial_API.Models;
using System.Threading;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// TODO: Add verification checks
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

        [HttpGet("p/{postId}")]
        public async Task<IActionResult> GetPost(Guid postId)
        {
            var post = await _db.Posts.Where(x => x.Id == postId).Include(x => x.User).Include(x => x.Community).FirstOrDefaultAsync();
            if (post == null) { return NotFound("Post not found"); }

            return Ok(post);
        }

        [HttpGet("c/{communityId}")]
        public async Task<IActionResult> GetCommunityPosts(Guid communityId)
        {
            var communityPostList = await _db.Posts.Where(x => x.CommunityId == communityId).Include(x => x.User).ToListAsync();
            return Ok(communityPostList);
        }

        [HttpGet("u/{userId}")]
        public async Task<IActionResult> GetUserPosts(Guid userId)
        {
            var userPostList = await _db.Posts.Where(x => x.UserId == userId).Include(x => x.Community).ToListAsync();
            return Ok(userPostList);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var postList = await _db.Posts.Include(x => x.User).Include(x => x.Community).ToListAsync();

            return Ok(postList);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel postModel, CancellationToken cancelToken)
        {
            var user = await _db.Users.FindAsync(postModel.UserId);
            if (user == null) { return NotFound("User not found"); }

            Post post = new()
            {
                UserId = postModel.UserId,
                CommunityId = postModel.CommunityId,
                Title = postModel.Title,
                Body = postModel.Body
            };

            _db.Posts.Add(post);
            await _db.SaveChangesAsync(cancelToken);

            return Ok(post.Id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(Guid postId, CancellationToken cancelToken)
        {
            Post post = await _db.Posts.FindAsync(postId);
            if (post is null) { return NotFound("Post not found"); }

            _db.Posts.Remove(post);
            await _db.SaveChangesAsync(cancelToken);

            return Ok();
        }
    }
}