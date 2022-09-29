namespace Commands.Models
{
    public class Command
    {
        public int Id { get; set; }
        // Non nullable properties must contain a non null value whene exiting the constructor
        public string HowTo { get; set; } = string.Empty;
        public string Line { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
    }
}