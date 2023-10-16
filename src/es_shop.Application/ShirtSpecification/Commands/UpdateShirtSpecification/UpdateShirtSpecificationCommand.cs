using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.ShirtSpecification.Commands.UpdateShirtSpecification;

public sealed record UpdateShirtSpecificationCommand(UploadImageRequest shirt) : IRequest<Result<ShirtResponse>>;