using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LynkerSocial_API.Models;
using LynkerSocial_API.ViewModels;
using System.Threading;

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

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel userModel, CancellationToken cancelToken)
        {
            Response response = new Response()
            {
                Success = true,
                Message = $"{userModel.Name} created."
            };

            // Prevalidates so this is obsolete

            // if (!ModelState.IsValid)
            // {
            //     // Sanity control
            //     response.Message = "Creation requirements not fulfilled";

            //     // Grab all errors
            //     // response.Message = string.Join(",", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));

            //     return BadRequest(response);
            // }

            User user = new User()
            {
                Name = userModel.Name,
                Birthday = userModel.Birthday
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync(cancelToken);

            return Ok(response);
        }
    }
}