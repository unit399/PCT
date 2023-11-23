using PCT.Application.Common.Contracts;

namespace PCT.Application.PersonalValue.Add;

public sealed record AddPersonalValueResponse : BaseResponse
{
    public string Name { get; set; } = string.Empty;
}