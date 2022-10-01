using Commands.Models;

// No database connection, so we will use a mock repository with hard-coded data

namespace Commands.Data
{
    public class MockCommandsRepo : ICommandsRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            // Initialize a list of commands
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
                new Command { Id = 1, HowTo = "Cut Bread", Line = "Get knife", Platform = "Knife & Chopping board" },
                new Command { Id = 3, HowTo = "Make tea", Line = "Get a teabag", Platform = "Kettle & Mug" },
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };

        }

    }
}