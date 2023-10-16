using System.Linq.Expressions;

namespace EsShop.Domain.Shared;

public class Filters<T> where T : class
{
    public Filters()
    {

    }
    public Filters(int pageSize, int pageNumber)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
