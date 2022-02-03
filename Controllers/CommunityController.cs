using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LynkerSocial_API.Models;
using LynkerSocial_API.ViewModels;
using System.Threading;
using Microsoft.EntityFrameworkCore;

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

            if (community == null)
            {
                return NotFound(ApiResponse<Community>.Failure("Community not found"));
            }

            return Ok(ApiResponse<Community>.Success(community));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommunities()
        {
            var communityList = await _db.Communities.ToListAsync();

            return Ok(ApiResponse<IEnumerable<Community>>.Success(communityList));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommunity(CommunityViewModel communityModel, CancellationToken cancelToken)
        {
            // @TODO: Add verification that user exists!

            Community community = new()
            {
                UserId = communityModel.UserId,
                Name = communityModel.Name,
                Description = communityModel.Description
            };

            _db.Communities.Add(community);
            await _db.SaveChangesAsync(cancelToken);

            return Ok(ApiResponse<Guid>.Success(community.Id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommunity(Guid communityId, CancellationToken cancelToken)
        {
            Community community = await _db.Communities.FindAsync(communityId);

            if (community is null)
            {
                return NotFound(ApiResponse.Failure("Community not found"));
            }

            _db.Communities.Remove(community);
            await _db.SaveChangesAsync(cancelToken);

            return Ok();
        }
    }
}