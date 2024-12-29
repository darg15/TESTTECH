using AutoMapper;
using TechnicalAPI.DTO;
using TechnicalAPI.Models;

namespace TechnicalAPI.Mappers
{
    public class MapperDTO : Profile
    {
       public MapperDTO()
       {
            CreateMap<MovDTO, Movs>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
        }
    }
}
