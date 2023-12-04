using Microsoft.EntityFrameworkCore;
using NajotNur.Domain.Models;

namespace NajotNur.Application.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NajotNurDbContext _najotNurDbContext;

        public UserRepository(NajotNurDbContext najotNurDbContext)
        {
            _najotNurDbContext = najotNurDbContext;
        }

        public async ValueTask CreateUser(User user)
        {
            try
            {
                await _najotNurDbContext.Users.AddAsync(user);
                await _najotNurDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }

        }

        public ValueTask CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<IEnumerable<User>> GetUsersAsync()
        {
            return await _najotNurDbContext.Users.ToListAsync();
        }

        public ValueTask<bool> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
