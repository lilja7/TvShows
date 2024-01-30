using AutoMapper;
using TvShows.Models;
using TvShows.Models.DTO;
namespace TvShows;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TvShow, TvShowDTO>();
        CreateMap<Actor, ActorDTO>()
            .ForMember(dest => dest.TvShows, opt => opt.MapFrom(src => src.TvShows));
    }
}