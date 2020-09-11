using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Models;

namespace MagusAppGateway.Services.Automapper
{
    public class AutomapperConfig:Profile
    {
        public AutomapperConfig()
        {
            CreateMap<UserDto, Users>();
            CreateMap<UserCreateDto, Users>();
            CreateMap<UserUpdateDto, Users>();

            CreateMap<IdentityResourceDto, IdentityResource>();
            CreateMap<IdentityResourceCreateDto, IdentityResource>();
            CreateMap<IdentityResourceUpdateDto, IdentityResource>();
        }
    }
}
