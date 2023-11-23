using Microsoft.AspNetCore.Identity;

namespace PCT.Domain.Account;

public class User : IdentityUser
{
    public byte[]? ProfilePicture { get; set; }
}