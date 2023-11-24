using Microsoft.AspNetCore.Identity;

namespace PCT.Domain.Account.Entities;

public class User : IdentityUser
{
    public byte[]? ProfilePicture { get; set; }
}