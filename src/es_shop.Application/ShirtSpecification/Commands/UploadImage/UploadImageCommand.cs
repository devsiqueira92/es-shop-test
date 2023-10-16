using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;
using Microsoft.AspNetCore.Http;

namespace EsShop.Application.ShirtSpecification.Commands.UploadImage;

public sealed record UploadImageCommand(IFormFileCollection files, Guid id) : IRequest<Result<ShirtResponse>>;