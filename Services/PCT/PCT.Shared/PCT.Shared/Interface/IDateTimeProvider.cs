namespace PCT.Shared.Interface;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}
