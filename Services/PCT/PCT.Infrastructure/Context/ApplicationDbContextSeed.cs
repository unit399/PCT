using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PCT.Domain.Account;

namespace PCT.Infrastructure.Context;

public class ApplicationDbContextSeed
{
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextSeed(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await SeedRolesAsync();
        await SeedAdminUserAsync();
    }

    private async Task SeedAdminUserAsync()
    {
        var user = new User
        {
            UserName = "okan.cilingiroglu@gmail.com",
            Email = "okan.cilingiroglu@gmail.com",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var userStore = new UserStore<User>(_context);

        var roleStore = new RoleStore<IdentityRole>(_context);

        if (!_context.Users.Any(u => u.UserName == user.UserName))
        {
            var password = new PasswordHasher<User>();
            var hashed = password.HashPassword(user, "password");
            user.PasswordHash = hashed;

            await userStore.CreateAsync(user);
            await userStore.AddToRoleAsync(user, UserRoles.Admin.ToUpper(CultureInfo.InvariantCulture));
        }

        await _context.SaveChangesAsync();
    }

    private async Task SeedRolesAsync()
    {
        if (!_context.Roles.Any(r => r.Name == UserRoles.Admin))
            _context.Roles.Add(new IdentityRole
            {
                Name = UserRoles.Admin,
                NormalizedName = UserRoles.Admin.ToUpper(CultureInfo.InvariantCulture)
            });

        if (!_context.Roles.Any(r => r.Name == UserRoles.Coach))
            _context.Roles.Add(new IdentityRole
            {
                Name = UserRoles.Coach,
                NormalizedName = UserRoles.Coach.ToUpper(CultureInfo.InvariantCulture)
            });

        if (!_context.Roles.Any(r => r.Name == UserRoles.Client))
            _context.Roles.Add(new IdentityRole
            {
                Name = UserRoles.Client,
                NormalizedName = UserRoles.Client.ToUpper(CultureInfo.InvariantCulture)
            });

        await _context.SaveChangesAsync();
    }
}