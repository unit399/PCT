namespace PCT.Application.Account.Register;

public sealed record RegisterUserResponse
{
    public RegisterUserResponse(Guid id, string email)
    {
        Id = id;
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }

    public Guid Id { get; set; }
    public string Email { get; set; }
}