using Microsoft.EntityFrameworkCore;

namespace PCT.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.PersonalValue.Entity.PersonalValue> PersonalValues { get; set; } = null!;
}