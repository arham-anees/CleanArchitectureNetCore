using System;

namespace CleanArhitectureNetCore.Domain.Common
{
    public abstract class AuditableBaseEntity : BaseEntity
    {
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
