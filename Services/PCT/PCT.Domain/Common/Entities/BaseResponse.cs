namespace PCT.Domain.Common.Entities;

public record BaseResponse
{
    public StatusCode? StatusCode { get; set; }
}