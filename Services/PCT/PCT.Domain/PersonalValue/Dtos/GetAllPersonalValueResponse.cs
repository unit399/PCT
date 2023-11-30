using PCT.Domain.Common.Entities;

namespace PCT.Domain.PersonalValue.Dtos;

public sealed record GetAllPersonalValueResponse : BaseResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}