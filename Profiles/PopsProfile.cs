using AutoMapper;
using OhMyPops.Dtos;
using OhMyPops.Models;

namespace OhMyPops.Profiles
{
    public class PopsProfile : Profile
    {
        public PopsProfile()
        {
            // Source -> Target
            CreateMap<Pop, PopReadDto>();
            CreateMap<PopCreateDto, Pop>();
            CreateMap<PopUpdateDto, Pop>();
        }
    }
}