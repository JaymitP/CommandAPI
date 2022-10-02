namespace Commands.Dtos
{
    // Defines the structure of the data that is returned to the client
    public class CommandReadDto
    {
        public int Id { get; set; }
        public string HowTo { get; set; } = string.Empty;
        public string Line { get; set; } = string.Empty;

        // Internal data that should not be exposed to the user
        // public string Platform { get; set; } = string.Empty;
    }
}