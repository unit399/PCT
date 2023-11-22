using AutoMapper;
using PCT.Domain.Account;

namespace PCT.Application.Account.GetAll;

public class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<User, GetAllUserResponse>();
    }
}