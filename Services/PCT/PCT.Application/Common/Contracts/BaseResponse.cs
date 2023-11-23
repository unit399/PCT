using PCT.Domain.Common.Entity;

namespace PCT.Application.Common.Contracts;

public record BaseResponse
{
    public StatusCode? StatusCode { get; set; }
}