using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using bookies.Models;
using bookies.Dtos;

namespace bookies.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>();
            Mapper.CreateMap<Author, AuthorDto>();
            Mapper.CreateMap<AuthorDto, Author>();
        }
    }
}