using Microsoft.EntityFrameworkCore;
using Plurish.Auth.Domain.Entities;
using Plurish.Auth.Domain.Repositories;
using Plurish.Auth.Infrastructure.DataAccess;

namespace Plurish.Auth.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _context;

    public UserRepository(AuthDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<bool> CreateAsync(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        _context.Users.Add(user);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<User?> GetByUsernameOrEmailAsync(string usernameOrEmail)
    {
        if (string.IsNullOrWhiteSpace(usernameOrEmail))
            throw new ArgumentException("The username or email must not be null or empty.", nameof(usernameOrEmail));

        return await _context.Users
            .FirstOrDefaultAsync(u => u.Name == usernameOrEmail || u.Email == usernameOrEmail);
    }

    public async Task<User?> GetByIdAsync(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("The user ID must not be empty.", nameof(userId));

        return await _context.Users.FindAsync(userId);
    }
}
