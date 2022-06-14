using AutoMapper;
using Services.DTO;
using Models;
namespace Services.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ToysDTO, Toys>();
            CreateMap<Toys, ToysViewModel>();
        }
    }
}
