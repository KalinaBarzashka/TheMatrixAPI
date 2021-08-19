namespace TheMatrixAPI.Mapping
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using TheMatrixAPI.Models.Actor;
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Models.DTO;
    using TheMatrixAPI.Models.DTO.Character;
    using TheMatrixAPI.Models.DTO.Race;
    using TheMatrixAPI.Models.Movie;
    using TheMatrixAPI.Models.Race;

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

            CreateMap<Movie, EditMovieViewModel>()
                .ForMember(
                    dto => dto.ReleaseDate,
                    opt => opt.MapFrom(src => src.ReleaseDate == null ? null : src.ReleaseDate.Value.ToString("dd/MM/yyyy")));
            CreateMap<Movie, DeleteMovieViewModel>()
                .ForMember(
                    dto => dto.ReleaseDate,
                    opt => opt.MapFrom(src => src.ReleaseDate == null ? null : src.ReleaseDate.Value.ToString("dd/MM/yyyy")));

            CreateMap<Movie, Movie>();

            CreateMap<Character, CharacterDTO>();

            CreateMap<Actor, DeleteActorViewModel>();

            CreateMap<Race, RaceDTO>();
            CreateMap<Race, EditRaceViewModel>();
            CreateMap<Race, DeleteRaceViewModel>();
            CreateMap<Race, RaceDetailsViewModel>();

            CreateMap<Character, RaceCharacterDTO>();
            CreateMap<Character, CharacterGroup>();
        }
    }
}
