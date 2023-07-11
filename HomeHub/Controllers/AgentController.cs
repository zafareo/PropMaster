using Application.UseCases.Agents.Commands;
using Application.UseCases.Agents.Queries;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GapKo_p.Controllers
{
    public class AgentController : ApiBaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AgentController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAgent([FromForm] CreateAgentCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }

        [HttpPost, ActionName("delete")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> DeleteAgent([FromForm] DeleteAgentCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }


        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> UpdateAgent([FromForm] UpdateAgentCommand command)
        {
            await _mediatr.Send(command);
            return View();
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAgents()
        {
            await _mediatr.Send(new GetAllAgentQuery());
            return View();
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetAgentById([FromQuery] GetAgentByIdQuery query)
        {
            await _mediatr.Send(query);
            return View();
        }
    }
}
