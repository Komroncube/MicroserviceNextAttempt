using NajotNur.Domain.Models;

namespace NajotNur.Application.Repositories.UserRepositories;

public interface IUserRepository
{
    ValueTask<IEnumerable<User>> GetUsersAsync();
    ValueTask CreateUserAsync(User user);
    ValueTask<bool> UpdateAsync(User user);
    ValueTask<bool> DeleteAsync(int id);
    ValueTask<User> GetByIdAsync(int id);
}
