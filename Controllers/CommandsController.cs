using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Commands.Models;
using Commands.Data;
using Commands.Dtos;

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
        private readonly IMapper _mapper;

        //Dependency injection -> recieves an instance of the repo interface to the controller when the interface is requested
        public CommandsController(ICommandsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            // Map the Command model to an IEnumerable of Read DTOs
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandByID(int id)
        {

            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
            {
                // Map the Command model to the Read DTO
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound(new { error = new { code = "404 Not Found", message = "Command not found" } });

        }
    }
}

