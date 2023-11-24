using AutoMapper;
using PCT.Domain.PersonalValue.Dtos;

namespace PCT.Application.PersonalValue.MappingProfiles;

public class GetAllPersonalValueMapper : Profile
{
    public GetAllPersonalValueMapper()
    {
        CreateMap<Domain.PersonalValue.Entities.PersonalValue, GetAllPersonalValueResponse>();
    }
}