using AutoMapper;
using TheMatrixAPI.Models.Actor;
using TheMatrixAPI.Models.DbModels;
using TheMatrixAPI.Models.DTO;

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

            CreateMap<Actor, ActorDTO>();
            CreateMap<Movie, ActorMovieDTO>()
                .ForMember(
                    dto => dto.Url,
                    opt => opt.MapFrom(src => "https://thematrixapi.com/api/movies/" + src.Id));
            CreateMap<Character, ActorCharacterDTO>()
                .ForMember(
                    dto => dto.Name,
                    opt => opt.MapFrom(src => src.Name));

            CreateMap<Actor, EditActorViewModel>();
            CreateMap<Character, ActorCharacterViewModel>()
                .ForMember(
                    dto => dto.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dto => dto.Name,
                    opt => opt.MapFrom(src => src.Name));
            CreateMap<Movie, ActorMovieViewModel>()
                .ForMember(
                    dto => dto.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dto => dto.Name,
                    opt => opt.MapFrom(src => src.Name));
        }
    }
}
