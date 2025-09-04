using AutoMapper;
using LoginUsers.Data.Dtos.UserDtos;
using LoginUsers.Models;

namespace LoginUsers.Profiles;

public class UserProfiles : Profile
{
    public UserProfiles()
    {
        CreateMap<CreateUserDto, User>();
    }
}
