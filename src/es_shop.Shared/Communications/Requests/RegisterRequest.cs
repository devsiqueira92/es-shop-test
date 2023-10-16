namespace EsShop.Shared.Communications.Requests;

public record RegisterRequest(string username, string email, string password, string passwordConfirmation);
