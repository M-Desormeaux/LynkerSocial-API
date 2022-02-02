using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LynkerSocial_API.Models;
using LynkerSocial_API.ViewModels;
using System.Threading;


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

        [HttpPost]
        public async Task<IActionResult> CreateCommunity(CommunityViewModel communityModel, CancellationToken cancelToken)
        {
            Response response = new Response()
            {
                Success = true,
                Message = "Community created."
            };

            // @TODO: Add verification that user exists!

            Community community = new Community()
            {
                UserId = communityModel.UserId,
                Name = communityModel.Name,
                Description = communityModel.Description
            };

            _db.Communities.Add(community);
            await _db.SaveChangesAsync(cancelToken);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommunity(Guid communityId, CancellationToken cancelToken)
        {
            Response response = new Response();

            Community community = await _db.Communities.FindAsync(communityId);

            if (community is null)
            {
                response.Message = "Communities not found";
                return NotFound(response);
            }

            response.Success = true;
            response.Message = $"{community.Name} deleted.";

            _db.Communities.Remove(community);
            await _db.SaveChangesAsync(cancelToken);

            return Ok(response);
        }
    }
}