using Gateway.WebApi.Data.Entieties;
using Gateway.WebApi.Dtos.User;
using AutoMapper;
using FluentAssertions.Common;
using Gateway.WebApi.Profiles.User;
using System.Drawing.Drawing2D;


namespace Gateway.WebApi.Profiles.User
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<AspNetUsers, UserReadDto>();


            CreateMap<UserCreateDto, AspNetUsers>();

        }
    }
}
