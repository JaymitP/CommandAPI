using System.ComponentModel.DataAnnotations;

namespace Commands.Dtos
{
    // Defines the structure of the data that is returned to the client
    // Same as Create Dto. Seperate class for maintainability

    public class CommandUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; } = string.Empty;

        [Required]
        public string Line { get; set; } = string.Empty;

        [Required]
        public string Platform { get; set; } = string.Empty;
    }
}