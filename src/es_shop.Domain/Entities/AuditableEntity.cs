using System.ComponentModel.DataAnnotations.Schema;

namespace EsShop.Domain.Entities;

public class AuditableEntity : BaseEntity
{
    public AuditableEntity()
    {
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
        Id = Guid.NewGuid();
    }
    [Column("DAT_CREATED_AT")]
    public DateTime CreatedAt { get; set; }
    [Column("DAT_UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
    [Column("FLG_IS_DELETED")]
    public bool IsDeleted { get; set; }
}
