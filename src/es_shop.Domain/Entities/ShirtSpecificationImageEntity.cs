namespace EsShop.Domain.Entities;

public class ShirtSpecificationImageEntity : AuditableEntity
{
	public Guid ImageId { get; set; }

	public Guid ShirtSpecificationId { get; set; }
    public ShirtSpecificationEntity ShirtSpecification { get; set; }


    public static ShirtSpecificationImageEntity Create(Guid shirtId, Guid imageId)
	{

		return new ShirtSpecificationImageEntity
		{
			ImageId = imageId,
			ShirtSpecificationId = shirtId,
		};
	}
}
