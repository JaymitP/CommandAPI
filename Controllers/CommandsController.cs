using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Commands.Models;
using Commands.Data;
using Commands.Dtos;


// Controller is used to handle HTTP requests and responses. Also accesses the repository.
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
        // Auto Mapper is used to map the DTO to the model or vice versa
        private readonly IMapper _mapper;

        //Dependency injection -> recieves an instance of the repo interface and AutoMapper instance (to the controller) when the interface is requested
        public CommandsController(ICommandsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet] // Endpoint for GET requests
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            // Map the Command model to an IEnumerable of Read DTOs
            // Ok is a helper method that returns a 200 OK status code
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // Endpoint for GET requests with an ID
        // Endpoint is named so the URI can be referenced in the POST request
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {

            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
            {
                // NotFound is a helper method that returns a 404 Not Found status code
                return NotFound(new { error = new { code = "404 Not Found", message = "Command not found" } });
            }
            // Map the Command model to the Read DTO
            return Ok(_mapper.Map<CommandReadDto>(commandItem));

        }

        [HttpPost] // Endpoint for POST requests
        // ActionResult returned since a success status code and the resource created is returned
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto? commandCreateDto)
        {
            // Map the Create DTO to the Command model so it can be added to the database
            var command = _mapper.Map<Command>(commandCreateDto);
            // Add the command to the db context
            _repository.CreateCommand(command);
            // Save the changes to the database, command is updated with the ID
            _repository.SaveChanges();

            // Map the Command model to the Read DTO
            var commandReadDto = _mapper.Map<CommandReadDto>(command);

            // CreatedAtRoute is a helper method that returns a 201 Created status code
            // The route name is used to generate the URI for the resource created -> in accordance with RESTful API design
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        [HttpPut("{id}")] // Endpoint for PUT requests
        // As per HTTP specification status code 200 and 201 are both applicable for a successful PUT request.
        public ActionResult UpdateCommand(int id, CommandUpdateDto? commandUpdateDto)
        {
            // Get the command to be updated from the database            
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound(new { error = new { code = "404 Not Found", message = "Command not found" } });
            }

            // Map the new command model to the existing command model from the repository
            // The command model from the repository is updated with the new values
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            // Save the changes to the database
            _repository.SaveChanges();

            return NoContent();
        }

    }
}

