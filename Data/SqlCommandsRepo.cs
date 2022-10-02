using Commands.Models;

namespace Commands.Data
{
    public class SqlCommandsRepo : ICommandsRepo
    {
        // DbContext class instance 
        private readonly CommandsContext _context;

        private static Exception _commandNotFoundException = new Exception("Command not found");

        // Dependency injection -> recieves an instance of the db context if the context is requested
        public SqlCommandsRepo(CommandsContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList().OrderBy(c => c.Id);

        }
        public Command? GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        // Changes made to the context are not saved until SaveChanges() is called
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        // Add the command to the context
        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        public void UpdateCommand(Command cmd)
        {
            // Do nothing
        }
    }
}