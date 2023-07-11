using Application.UseCases.Properties.Commands;
using Application.UseCases.Properties.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GapKo_p.Controllers
{
    [Route("api/[controller]")]
    public class PropertyController : ApiBaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProperty([FromForm] CreatePropertyCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> DeleteProperty([FromForm] DeletePropertyCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> UpdateProperty([FromForm] UpdatePropertyCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProperties()
        {
            await _mediatr.Send(new GetAllPropertiesQuery());
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPropertyById([FromQuery] GetPropertyByIdQuery query)
        {
            await _mediatr.Send(query);
            return View();
        }
    }
}
