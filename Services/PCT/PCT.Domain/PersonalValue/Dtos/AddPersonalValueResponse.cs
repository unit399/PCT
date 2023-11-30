using PCT.Domain.Common.Entities;

namespace PCT.Domain.PersonalValue.Dtos;

public sealed record AddPersonalValueResponse : BaseResponse
{
    public string Name { get; set; } = string.Empty;
}