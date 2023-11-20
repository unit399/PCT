using Microsoft.EntityFrameworkCore;

namespace PCT.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Domain.Account.User> Users { get; set; }
    public DbSet<Domain.PersonalValue.PersonalValue> PersonalValues { get; set; }
}