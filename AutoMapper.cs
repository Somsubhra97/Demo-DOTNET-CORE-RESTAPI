using System.Linq;
using AutoMapper;
using Project.Dtos.Command;
using Project.Models;

namespace Project
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Command, GetCommandDto>();   
            CreateMap<AddCharacterDto, Character>();         
        }
    }
}

