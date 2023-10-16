namespace EsShop.Shared.Communications.Responses;

public record ShirtResponse(string? name, Guid colorId, Guid fabricId, Guid id);