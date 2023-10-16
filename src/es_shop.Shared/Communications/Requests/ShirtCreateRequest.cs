namespace EsShop.Shared.Communications.Requests;

public record ShirtCreateRequest(string name, Guid colorId, Guid fabricId);