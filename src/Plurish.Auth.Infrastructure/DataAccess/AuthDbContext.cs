using Microsoft.EntityFrameworkCore;
using Plurish.Auth.Domain.Entities;

namespace Plurish.Auth.Infrastructure.DataAccess;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);

        ApplyConfigurations(modelBuilder);
    }

    private void ApplyConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Username).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(150);
            entity.Property(u => u.Password).IsRequired().HasMaxLength(525);
            entity.Property(u => u.Role).IsRequired();
            entity.Property(u => u.TwoFactorCode).HasMaxLength(10);
            entity.Property(u => u.TwoFactorExpiration).HasMaxLength(10);

            // Indexes para melhorar consultas.
            entity.HasIndex(u => u.Email).IsUnique();

            // Controle de criação e ativação.
            entity.Property(u => u.CreatedOn).IsRequired();
            entity.Property(u => u.IsActive).HasDefaultValue(true);
        });
    }
}
