using Application.UseCases.Owners.Commands;
using Application.UseCases.Owners.Queries;
using GapKo_p.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HomeHub.Controllers
{
    public class OwnerController : ApiBaseController
    {
       
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateOwner([FromForm] CreateOwnerCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }

        
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> DeleteOwner([FromForm] DeleteOwnerCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> UpdateOwner([FromForm] UpdateOwnerCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }

        public async Task<IActionResult> GetAllOwner()
        {
            await _mediatr.Send(new GetAllOwnersQuery());
            return View();
        }

        public async Task<IActionResult> GetOwnerById([FromQuery] GetOwnerByIdQuery query)
        {
            await _mediatr.Send(query);
            return View();
        }
    }
}
