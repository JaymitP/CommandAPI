using Commands.Models;
using Microsoft.EntityFrameworkCore;

namespace Commands.Data
{
    // Class instance can be used to query db, similar to ReactJS context providers
    public class CommandsContext : DbContext
    {
        // Constructor initializer, calls base class (DbContext) constructor with parameter.
        public CommandsContext(DbContextOptions<CommandsContext> opt) : base(opt)
        {

        }
        // Create a representation of the model in the database as a DbSet.
        // Each model class requires its own mapping to the database.
        public DbSet<Command> Commands { get; set; } = null!;

    }
}