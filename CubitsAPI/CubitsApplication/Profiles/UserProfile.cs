using AutoMapper;
using CubitsApplication.Models;
using CubitsDomain.Entities;

namespace CubitsApplication.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
