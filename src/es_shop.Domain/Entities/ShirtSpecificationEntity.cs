namespace EsShop.Domain.Entities;

public class ShirtSpecificationEntity : AuditableEntity
{
	public ColorEntity? ColorEntity { get; set; }
	public Guid ColorId { get; set; }
	public FabricEntity? FabricEntity { get; set; }
	public Guid FabricId { get; set; }

	public ShirtEntity? ShirtEntity { get; set; }
	public Guid ShirtId { get; set; }

	public static ShirtSpecificationEntity Create(Guid shirtId, Guid colorId, Guid fabricId)
	{

		return new ShirtSpecificationEntity
		{
			ColorId = colorId,
			ShirtId = shirtId,
			FabricId = fabricId
		};
	}

	public void Update(string name, Guid colorId, Guid fabricId)
	{
		ColorId = colorId;
		FabricId = fabricId;

		UpdatedAt = DateTime.UtcNow;
	}
}
