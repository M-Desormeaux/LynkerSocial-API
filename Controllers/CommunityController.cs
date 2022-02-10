using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LynkerSocial_API.Models;
using LynkerSocial_API.ViewModels;
using System.Threading;
using Microsoft.EntityFrameworkCore;

// TODO: Add verification checks

namespace LynkerSocial_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommunityController : ControllerBase
    {
        private readonly LynkerdbContext _db;

        public CommunityController(LynkerdbContext db)
        {
            _db = db;
        }

        [HttpGet("{communityId}")]
        public async Task<IActionResult> GetCommunity(Guid communityId)
        {
            var community = await _db.Communities.FindAsync(communityId);
            if (community == null) { return NotFound("Community not found"); }

            return Ok(community);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommunities()
        {
            var communityList = await _db.Communities.ToListAsync();

            return Ok(communityList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommunity(CommunityViewModel communityModel, CancellationToken cancelToken)
        {
            var user = await _db.Users.FindAsync(communityModel.UserId);
            if (user == null) { return NotFound("User not found"); }

            Community community = new()
            {
                UserId = communityModel.UserId,
                Name = communityModel.Name,
                Description = communityModel.Description
            };

            _db.Communities.Add(community);
            await _db.SaveChangesAsync(cancelToken);

            return Ok(community.Id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommunity(Guid communityId, CancellationToken cancelToken)
        {
            Community community = await _db.Communities.FindAsync(communityId);
            if (community is null) { return NotFound("Community not found"); }

            _db.Communities.Remove(community);
            await _db.SaveChangesAsync(cancelToken);

            return Ok();
        }
    }
}