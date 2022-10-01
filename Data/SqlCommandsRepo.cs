using Commands.Models;

namespace Commands.Data
{
    public class SqlCommandsRepo : ICommandsRepo
    {
        // DbContext class instance 
        private readonly CommandsContext _context;

        // Dependency injection -> recieves an instance of the db context if the context is requested
        public SqlCommandsRepo(CommandsContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList().OrderBy(c => c.Id);

        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id) ?? throw new Exception($"Command with id {id} was not found");
        }
    }
}