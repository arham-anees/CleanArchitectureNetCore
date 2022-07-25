using System;

namespace CleanArhitectureNetCore.Domain.Common
{
    public static class AuditableBaseEntityExtensions
    {
        public static void UpdateAudit(this AuditableBaseEntity entity, long userId)
        {
            if (entity.Id <= 0)
            {
                entity.CreatedOn = DateTime.UtcNow;
                entity.CreatedBy = userId;
            }
            entity.LastModifiedBy = userId;
            entity.LastModifiedOn = DateTime.UtcNow;
        }
    }
}
