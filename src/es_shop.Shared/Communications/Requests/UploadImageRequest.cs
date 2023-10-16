using Microsoft.AspNetCore.Http;

namespace EsShop.Shared.Communications.Requests;

public record UploadImageRequest(Guid shirtSpecificationId, List<IFormFile> request);

