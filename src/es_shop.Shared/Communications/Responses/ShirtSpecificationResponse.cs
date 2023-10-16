namespace EsShop.Shared.Communications.Responses;

public record ShirtSpecificationResponse(Guid? shirtId, Guid colorId, Guid fabricId, Guid id);