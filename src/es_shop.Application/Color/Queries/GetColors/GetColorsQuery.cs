using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Color.Queries.GetColors;
public record GetColorsQuery(int pageSize = 10, int page = 1) : IRequest<Result<IList<ColorResponse>>>;
