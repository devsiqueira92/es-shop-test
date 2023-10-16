namespace EsShop.Shared.Communications.Requests;

public record ShirtUpdateRequest(Guid id, string name, Guid colorId, Guid fabricId);
