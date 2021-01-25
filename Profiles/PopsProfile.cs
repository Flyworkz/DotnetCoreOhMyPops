using AutoMapper;
using OhMyPops.Dtos;
using OhMyPops.Models;

namespace OhMyPops.Profiles
{
    public class PopsProfile : Profile
    {
        public PopsProfile()
        {
            CreateMap<Pop, PopReadDto>();
        }
    }
}