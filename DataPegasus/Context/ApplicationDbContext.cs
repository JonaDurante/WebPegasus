using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pegasus.Data.AppyUser;
using System.Reflection.Emit;

namespace Pegasus.Data.Context;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    private readonly ILoggerFactory _loggerFactory;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggerFactory loggerFactory)
            : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<AppUser>().ToTable("Usuarios");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UsuariosRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UsuariosClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UsuariosLogins");
        builder.Entity<IdentityUserToken<string>>().ToTable("UsuariosTokens");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RolesClaims");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var logger = _loggerFactory.CreateLogger<ApplicationDbContext>();
        optionsBuilder.LogTo(d => logger.Log(LogLevel.Error, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Error)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }

}
