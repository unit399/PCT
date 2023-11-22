using PCT.Domain.Common.Enum;

namespace PCT.Domain.Common.Entity;

public sealed class StatusCode
{
    public StatusCodeType Type { get; set; }
    public string Message { get; set; } = string.Empty;
}