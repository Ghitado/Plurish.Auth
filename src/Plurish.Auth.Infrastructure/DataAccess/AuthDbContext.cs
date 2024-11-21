using Microsoft.EntityFrameworkCore;
using Plurish.Auth.Domain.Entities;

namespace Plurish.Auth.Infrastructure.DataAccess;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ApplyConfigurations(modelBuilder);
    }

    private void ApplyConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id); 
            entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(150);
            entity.Property(u => u.Password).IsRequired();
            entity.Property(u => u.Role).IsRequired();
            entity.Property(u => u.TwoFactorCode).HasMaxLength(10); 
            entity.Property(u => u.TwoFactorExpiration).IsRequired();

            // Indexes para melhorar consultas.
            entity.HasIndex(u => u.Email).IsUnique();

            // Controle de criação e ativação.
            entity.Property(u => u.CreatedOn).IsRequired();
            entity.Property(u => u.IsActive).HasDefaultValue(true);
        });
    }
}
