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
        public string HowTo { get; set; } = null!;

        [Required]
        public string Line { get; set; } = null!;

        [Required]
        public string Platform { get; set; } = null!;
    }
}