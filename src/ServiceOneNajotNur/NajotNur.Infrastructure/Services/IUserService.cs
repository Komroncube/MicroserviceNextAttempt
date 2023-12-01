using NajotNur.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajotNur.Infrastructure.Services
{
    public interface IUserService
    {
        ValueTask<IEnumerable<User>> GetUsersAsync();
        ValueTask CreateUserAsync(User user);
    }
}
