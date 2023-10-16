using Microsoft.AspNetCore.Http;

namespace EsShop.Domain.RepositoryInterfaces;

public interface IAzureBlobStorageHandler
{
	List<Guid> FakeUploadBlob(IFormFileCollection formFile, string? originalBlobName = null);
	Task<string> UploadBlob(IFormFile formFile, string? originalBlobName = null);
	Task<string> GetBlobUrl(string imageName);
    Task RemoveBlob(string imageName);
}
