using Microsoft.EntityFrameworkCore;
using Plurish.Auth.Domain.Entities;
using Plurish.Auth.Domain.Repositories;
using Plurish.Auth.Infrastructure.DataAccess;

namespace Plurish.Auth.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _dbContext;

    public UserRepository(AuthDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<User> GetByEmailAsync(string email) => await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<bool> CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task DeleteAsync(Guid userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
