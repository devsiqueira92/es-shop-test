namespace EsShop.Shared.Communications.Requests;

public record ShirtSpecificationCreateRequest(Guid shirtId, Guid colorId, Guid fabricId);

