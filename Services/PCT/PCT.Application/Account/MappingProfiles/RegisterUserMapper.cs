using AutoMapper;
using PCT.Domain.Account.Dtos;
using PCT.Domain.Account.Entities;

namespace PCT.Application.Account.MappingProfiles;

public sealed class RegisterUserMapper : Profile
{
    public RegisterUserMapper()
    {
        CreateMap<RegisterUserRequest, User>();
        CreateMap<User, RegisterUserResponse>();
    }
}