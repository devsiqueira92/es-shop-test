using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Fabric.Commands.UpdateFabric;

public sealed record UpdateFabricCommand(FabricUpdateRequest fabric) : IRequest<Result<FabricResponse>>;