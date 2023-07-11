using Application.UseCases.Users.Commands;
using Application.UseCases.Users.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GapKo_p.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiBaseController
    {
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> DeleteUser([FromForm] DeleteUserCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }


        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAllUser()
        {
            await _mediatr.Send(new GetAllUsersQuery());
            return View();
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetByIdUser([FromQuery] GetByIdUserQuery command)
        {
            await _mediatr.Send(command);
            return View();
        }
    }
}
