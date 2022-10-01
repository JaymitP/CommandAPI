using AutoMapper;
using Commands.Dtos;
using Commands.Models;

namespace Commands.Profiles
{
    // Map models to DTOs
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            // Map the Command model to the Read DTO
            CreateMap<Command, CommandReadDto>();
        }
    }
}