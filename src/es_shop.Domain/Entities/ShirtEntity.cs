namespace EsShop.Domain.Entities;

public class ShirtEntity : AuditableEntity
{
    public string? Name { get; set; }

    public static ShirtEntity Create(string name, Guid colorId, Guid fabricId)
    {
       
        return new ShirtEntity
        {
            Name = name,
        };
    }

    public void Update(string name, Guid colorId, Guid fabricId)
    {
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }
}
