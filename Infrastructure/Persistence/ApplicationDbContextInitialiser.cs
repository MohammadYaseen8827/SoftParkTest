using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Platform.Application.Enums;
using Platform.Infrastructure.Identity.Models;

namespace Platform.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        await SeedRolesAsync();

        await SeedDefaultUserAsync();

        await SeedSuperAdminAsync();
    }

    //Seed Roles
    public async Task SeedRolesAsync()
    {
        await _roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
        await _roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        await _roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
        await _roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
    }

    //Seed Super Admin
    public async Task SeedSuperAdminAsync()
    {
        var defaultUser = new ApplicationUser
        {
            UserName = "SuperAdmin",
            Email = "SuperAdmin@gmail.com",
            FirstName = "Yaseen",
            LastName = "Mohammad",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (_userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await _userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await _userManager.CreateAsync(defaultUser, "P@ssw0rd@123");
                await _userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                await _userManager.AddToRoleAsync(defaultUser, Roles.Moderator.ToString());
                await _userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                await _userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
            }
        }
    }

    //Seed Default User
    public async Task SeedDefaultUserAsync()
    {
        var defaultUser = new ApplicationUser
        {
            UserName = "BasicUser",
            Email = "BasicUser@gmail.com",
            FirstName = "Mohammad",
            LastName = "Yaseen",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (_userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await _userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await _userManager.CreateAsync(defaultUser, "P@ssw0rd@123");
                await _userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
            }

        }
    }


}
