namespace EsShop.Shared.Communications.Responses;

public record LoginResponse(string token, string? username);