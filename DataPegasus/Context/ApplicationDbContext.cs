using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pegasus.Data.AppIdentityUser;

namespace Pegasus.Data.Context;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    private readonly ILoggerFactory _loggerFactory;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggerFactory loggerFactory)
            : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUser>().ToTable("Usuarios");
        modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UsuariosRoles");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UsuariosClaims");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsuariosLogins");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsuariosTokens");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RolesClaims");
    }

    public DbSet<AppUser> AppUser {  get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var logger = _loggerFactory.CreateLogger<ApplicationDbContext>();
        optionsBuilder.LogTo(d => logger.Log(LogLevel.Error, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Error)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
}
