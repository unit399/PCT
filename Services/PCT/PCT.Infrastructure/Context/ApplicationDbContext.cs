using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCT.Domain.Account.Entities;
using PCT.Domain.PersonalValue.Entities;
using PCT.Domain.Session.Entities;

namespace PCT.Infrastructure.Context;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Coach> Coaches { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<PersonalValue> PersonalValues { get; set; }
}