namespace EsShop.Shared.Communications.Requests;

public record ColorUpdateRequest(Guid id, string colorName, string hex);
