using AutoMapper;
using TheMatrixAPI.Models.DbModels;
using TheMatrixAPI.Models.DTO;
using TheMatrixAPI.Models.Movie;

namespace TheMatrixAPI.Mapping
{
    public class TheMatrixApiMappingProfile : Profile
    {
        public TheMatrixApiMappingProfile()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<Actor, MovieActorDTO>()
                .ForMember(
                    dto => dto.Url, 
                    opt => opt.MapFrom(src => "https://thematrixapi.com/api/actors/" + src.Id));
            CreateMap<Race, MovieRaceDTO>()
                .ForMember(
                    dto => dto.Url,
                    opt => opt.MapFrom(src => "https://thematrixapi.com/api/races/" + src.Id));
        }
    }
}
