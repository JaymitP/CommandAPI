using System.ComponentModel.DataAnnotations;

namespace Commands.Models
{
    public class Command
    {
        [Key] // Not required, but good practice to include
        public int Id { get; set; }

        // Non nullable properties must contain a non null value whene exiting the constructor
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; } = string.Empty;


        public string Line { get; set; } = string.Empty;

        [Required]
        public string Platform { get; set; } = string.Empty;
    }
}