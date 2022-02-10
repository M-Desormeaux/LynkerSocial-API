using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LynkerSocial_API.Models;
using LynkerSocial_API.ViewModels;
using System.Threading;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

// TODO: Add verification checks

namespace LynkerSocial_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly LynkerdbContext _db;

        public UserController(LynkerdbContext db)
        {
            _db = db;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null) { return NotFound("User not found"); }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var userList = await _db.Users.ToListAsync();

            return Ok(userList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel userModel, CancellationToken cancelToken)
        {
            User user = new()
            {
                Name = userModel.Name,
                Birthday = userModel.Birthday
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync(cancelToken);

            return Ok(user.Id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid userId, CancellationToken cancelToken)
        {
            User user = await _db.Users.FindAsync(userId);
            if (user is null) { return NotFound("User not found"); }

            _db.Users.Remove(user);
            await _db.SaveChangesAsync(cancelToken);

            return Ok();
        }
    }
}