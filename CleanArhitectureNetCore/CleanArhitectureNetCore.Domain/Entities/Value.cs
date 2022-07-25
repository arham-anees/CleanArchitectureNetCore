using CleanArhitectureNetCore.Domain.Common;

namespace CleanArhitectureNetCore.Domain.Entities
{
    public class Value : AuditableBaseEntity
    {
        public string Val { get; set; }
    }
}
