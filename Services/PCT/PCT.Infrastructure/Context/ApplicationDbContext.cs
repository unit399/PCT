using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCT.Domain.Account.Entities;
using PCT.Domain.PersonalValue.Entities;

namespace PCT.Infrastructure.Context;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<PersonalValue> PersonalValues { get; set; }
}