using AutoMapper;
using CleanArquitecture.Application.Features.Directors.Commands.CreateDirector;
using CleanArquitecture.Application.Features.Streamers.Commands;
using CleanArquitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArquitecture.Domain;

namespace CleanArquitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVM>();
            CreateMap<CreateStreamerCommand, Streamer>();
            CreateMap<CreateDirectorCommand, Director>();
        }
    }
}