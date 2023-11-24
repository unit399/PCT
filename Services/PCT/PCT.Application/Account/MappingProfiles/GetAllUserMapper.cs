using AutoMapper;
using PCT.Domain.Account.Dtos;
using PCT.Domain.Account.Entities;

namespace PCT.Application.Account.MappingProfiles;

public class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<User, GetAllUserResponse>();
    }
}