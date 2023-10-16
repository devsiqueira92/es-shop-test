using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using EsShop.Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EsShop.Infrastructure.Repositories;

internal class AzureBlobStorageHandler : IAzureBlobStorageHandler
{
	private readonly BlobServiceClient _blobServiceClient;
	private readonly IConfiguration _configuration;
	public AzureBlobStorageHandler(IConfiguration configuration, BlobServiceClient blobServiceClient)
    {
        _configuration = configuration;
        _blobServiceClient = blobServiceClient;
    }

    public async Task<string> UploadBlob(IFormFile formFile, string? originalBlobName = null)
    {
        var blobName = Guid.NewGuid().ToString();
        var container = _blobServiceClient.GetBlobContainerClient(_configuration.GetSection("Azure:Container").Value);

        if (!string.IsNullOrEmpty(originalBlobName))
        {
            await RemoveBlob(originalBlobName);
        }

        using var memoryStream = new MemoryStream();
        formFile.CopyTo(memoryStream);
        memoryStream.Position = 0;
        var blob = container.GetBlobClient(blobName);


        await blob.UploadAsync(content: memoryStream, overwrite: true);

        BlobSasBuilder blobSasBuilder = new()
        {
            BlobContainerName = blob.BlobContainerName,
            BlobName = blob.Name,
            ExpiresOn = DateTime.UtcNow.AddMinutes(2),
            Protocol = SasProtocol.Https,
            Resource = "b"
        };
        blobSasBuilder.SetPermissions(BlobAccountSasPermissions.Read);

        return blob.GenerateSasUri(blobSasBuilder).ToString();
    }

    public async Task<string> GetBlobUrl(string imageName)
    {
        if (string.IsNullOrEmpty(imageName))
            return string.Empty;

        var container = _blobServiceClient.GetBlobContainerClient("images");

        var blob = container.GetBlobClient(imageName);

        BlobSasBuilder blobSasBuilder = new()
        {
            BlobContainerName = blob.BlobContainerName,
            BlobName = blob.Name,
            ExpiresOn = DateTime.UtcNow.AddMinutes(2),
            Protocol = SasProtocol.Https,
            Resource = "b"
        };
        blobSasBuilder.SetPermissions(BlobAccountSasPermissions.Read);

        return blob.GenerateSasUri(blobSasBuilder).ToString();
    }

    public async Task RemoveBlob(string imageName)
    {
        var container = _blobServiceClient.GetBlobContainerClient("images");
        var blob = container.GetBlobClient(imageName);
        await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
    }

	public List<Guid> FakeUploadBlob(IFormFileCollection formFile, string? originalBlobName = null)
	{
        List<Guid> filesId = new List<Guid>();
        foreach (var item in formFile)
        {
			var blobId = Guid.NewGuid();

			//implment logic as UploadBlob method

            filesId.Add(blobId);
		}

        return filesId;
	}
}
