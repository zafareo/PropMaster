using Application.UseCases.Permissions.Commands;
using Application.UseCases.Permissions.Queries;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GapKo_p.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ApiBaseController
    {
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePermission([FromForm] CreatePermissionCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> DeletePermission([FromForm] DeletePermissionCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }


        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> UpdatePermission([FromForm] UpdatePermissionCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAllPermission()
        {
            await _mediatr.Send(new GetAllPermissionsQuery());
            return View();
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetByIdPermission([FromQuery] GetByIdPermissionQuery command)
        {
            await _mediatr.Send(command);
            return View();
        }
    }
}
