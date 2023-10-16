namespace EsShop.Domain.Entities;

public class ColorEntity : AuditableEntity
{
    public string? Color { get; set; }
    public string? Hex { get; set; }

    public static ColorEntity Create(string color, string hex)
    {
        return new ColorEntity { Color = color, Hex = hex};
    }

    public void Update(string color, string hex)
    {
        Color = color;
        Hex = hex;
        UpdatedAt = DateTime.UtcNow;
    }

}
