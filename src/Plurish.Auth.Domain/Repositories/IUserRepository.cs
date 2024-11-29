using Plurish.Auth.Domain.Entities;

namespace Plurish.Auth.Domain.Repositories;
public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    Task<bool> CreateAsync(User user);
    Task<bool> UpdateAsync(User user);
    Task DeleteAsync(Guid userId);
}
