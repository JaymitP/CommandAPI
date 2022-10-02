using AutoMapper;
using Commands.Dtos;
using Commands.Models;

namespace Commands.Profiles
{
    // Map Models to DTOs and vice versa
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            // Map the Command model to the Read DTO
            CreateMap<Command, CommandReadDto>();

            // Map Create DTO to the Command Model
            CreateMap<CommandCreateDto, Command>();

            CreateMap<CommandUpdateDto, Command>();

            // For PATCH requests
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}