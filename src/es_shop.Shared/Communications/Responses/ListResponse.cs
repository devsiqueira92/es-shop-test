namespace EsShop.Shared.Communications.Responses
{
    public record ListResponse<T>(IList<T> list, object? metadata = null);
}
