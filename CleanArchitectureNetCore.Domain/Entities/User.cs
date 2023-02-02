using CleanArchitectureNetCore.Domain.Common;

namespace CleanArchitectureNetCore.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
