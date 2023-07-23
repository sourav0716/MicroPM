using ProjectService.Domain.Common;

namespace ProjectService.Domain.Entity
{
    public class User : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public User(string name, string email, Role role)
        {
            Name = name;
            Email = email;
            Role = role;
        }
    }
}