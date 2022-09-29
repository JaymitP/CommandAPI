using Microsoft.AspNetCore.Mvc;
using Commands.Models;
using Commands.Data;

namespace Commands.Controllers
{

    //Route matches URI to each method in the controller class, the [] attribute is substituted with class name during runtime
    [Route("api/[controller]")]
    //Provide default API behavior
    [ApiController]

    // Implements ControllerBase since view support is not needed, otherwise use Controller interface
    public class CommandsController : ControllerBase
    {
        // private readonly ILogger<WeatherForecastController> _logger;

        // public WeatherForecastController(ILogger<WeatherForecastController> logger)
        // {
        //     _logger = logger;
        // }

        private readonly MockCommandsRepo _repository = new MockCommandsRepo();

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();

            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandByID(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
        }
    }
}

