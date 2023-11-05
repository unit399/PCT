using PCT.Application.Common.Interfaces.Services;

namespace PCT.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}