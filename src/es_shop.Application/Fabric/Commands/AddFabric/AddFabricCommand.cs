using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Fabric.Commands.AddFabric;

public sealed record AddFabricCommand(FabricCreateRequest fabric) : IRequest<Result<FabricResponse>>;

