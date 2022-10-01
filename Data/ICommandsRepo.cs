
using Commands.Models;


namespace Commands.Data
{

    // Seperation of interface from implementation -> decoupling code
    // Interface will contain all of the methods that the repository should provide to the consumer.
    public interface ICommandsRepo
    {

        // Return a list of all commands, hence enumerable to support iteration
        IEnumerable<Command> GetAllCommands();

        // Return a single command given an id
        Command? GetCommandById(int id);
    }
}