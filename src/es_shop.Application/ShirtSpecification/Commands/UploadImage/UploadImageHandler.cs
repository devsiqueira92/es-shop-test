using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;
using EsShop.Domain.Entities;

namespace EsShop.Application.ShirtSpecification.Commands.UploadImage;

internal sealed class UploadImageHandler : IRequestHandler<UploadImageCommand, Result<ShirtResponse>>
{
	private readonly IShirtSpecificationImageRepository _shirtImageRepository;
	private readonly IAzureBlobStorageHandler _blobRepository;
	private readonly IShirtRepository _shirtRepository;
	private readonly IUnitOfWork _unitOfWork;

    public UploadImageHandler(IShirtRepository shirtRepository, IUnitOfWork unitOfWork)
    {
        _shirtRepository = shirtRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ShirtResponse>> Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        var blobs = _blobRepository.FakeUploadBlob(request.files);
        var listImage = new List<ShirtSpecificationImageEntity>();

        foreach (var blob in blobs) 
        {
            var obj = ShirtSpecificationImageEntity.Create(request.id, blob);
            listImage.Add(obj);
        }

        await _shirtImageRepository.BulkCreateAsync(listImage);
        await _unitOfWork.SaveChangesAsync();

        return new ShirtResponse("", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
    }
}
