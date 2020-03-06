using Microsoft.AspNetCore.Mvc;

namespace marsroverapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandService _commandService;
        public CommandController(ICommandService commandService)
        {
            _commandService = commandService;
        }

         [HttpGet]
        public ActionResult<ResultObjectDto> Get(RoverCommandDto roverCommandDto)
        {
            return _commandService.MoveRover(roverCommandDto);
        }
    }
}