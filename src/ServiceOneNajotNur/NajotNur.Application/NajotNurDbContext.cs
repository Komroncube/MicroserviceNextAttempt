using Microsoft.EntityFrameworkCore;
using NajotNur.Domain.Models;

namespace NajotNur.Application
{
    public class NajotNurDbContext : DbContext
    {
        public NajotNurDbContext(DbContextOptions<NajotNurDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public virtual DbSet<User> Users { get; set; }
    }
}
