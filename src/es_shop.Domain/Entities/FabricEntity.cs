namespace EsShop.Domain.Entities;

public class FabricEntity : AuditableEntity
{
    public string? Type { get; set; }
    public static FabricEntity Create(string type)
    {
        return new FabricEntity { Type = type };
    }

    public void Update(string type)
    {
        Type = type;
        UpdatedAt = DateTime.UtcNow;
    }
}
