using Plurish.Auth.Domain.Entities;

namespace Plurish.Auth.Domain.Repositories;
public interface IUserRepository
{
    Task<bool> CreateAsync(User user);
    Task<User?> GetByUsernameOrEmailAsync(string usernameOrEmail);
    Task<User?> GetByIdAsync(Guid userId);
}
