using System.ComponentModel.DataAnnotations.Schema;

namespace EsShop.Domain.Entities;

public abstract class BaseEntity
{
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
}
