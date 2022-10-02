using System.ComponentModel.DataAnnotations;

namespace Commands.Dtos
{
    // Defines the structure of the data that is returned to the client
    public class CommandCreateDto
    {
        // Id is not required as it is created by the database
        // public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; } = string.Empty;

        [Required]
        public string Line { get; set; } = string.Empty;

        [Required]
        public string Platform { get; set; } = string.Empty;
    }
}