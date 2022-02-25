﻿using AutoMapper;
using CleanArquitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArquitecture.Domain;

namespace CleanArquitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVM>();
        }
    }
}