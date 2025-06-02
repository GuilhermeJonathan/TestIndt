using AutoMapper;
using TestIndt.Application.CrossCutting.DTO.Routes;
using TestIndt.Domain.Entities;

namespace TestIndt.Application.Profiles
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<Route, RouteDTO>();

        }
    }
}