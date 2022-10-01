namespace Commands.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }
        public string HowTo { get; set; } = string.Empty;
        public string Line { get; set; } = string.Empty;

        // Internal data that should not be exposed to the user
        // public string Platform { get; set; } = string.Empty;
    }
}