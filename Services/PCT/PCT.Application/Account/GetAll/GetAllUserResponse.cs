namespace PCT.Application.Account.GetAll;

public sealed record GetAllUserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
}