using NajotNur.Domain.Enums;

namespace NajotNur.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
