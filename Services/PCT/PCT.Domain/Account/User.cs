using PCT.Domain.Common;

namespace PCT.Domain.Account;

public class User: BaseEntity
{
    public User(string email, string password)
    {
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Password = password ?? throw new ArgumentNullException(nameof(password));
    }

    public string Email { get; set; }
    public string Password { get; set; }
}