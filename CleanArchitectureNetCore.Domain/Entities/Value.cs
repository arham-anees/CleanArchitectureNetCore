using CleanArchitectureNetCore.Domain.Common;

namespace CleanArchitectureNetCore.Domain.Entities
{
    public class Value : AuditableBaseEntity
    {
        public string Val { get; set; }
    }
}
