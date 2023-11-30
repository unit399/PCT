using PCT.Domain.Common.Enums;

namespace PCT.Domain.Common.Entities;

public sealed class StatusCode
{
    public StatusCodeType Type { get; set; }
    public string Message { get; set; } = string.Empty;
}