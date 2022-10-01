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
        private readonly ICommandsRepo _repository;

        //Dependency injection -> recieves an instance of the repo interface to the controller when the interface is requested
        public CommandsController(ICommandsRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandByID(int id)
        {
            try
            {
                var commandItem = _repository.GetCommandById(id);
                return Ok(commandItem);
            }
            catch
            {
                return NotFound("Command not found");
            }
        }
    }
}

