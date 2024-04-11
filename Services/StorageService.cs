using Azure.Storage.Blobs;

namespace Gamma_News.Services
{
    public class StorageService : IStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobServiceClient;
        private Stream fileNameWithPath;

        public StorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _blobServiceClient = new BlobServiceClient(
                _configuration["AzureWebJobsStorage"]);
        }
        public Uri UploadBlob(string blobName)
        {
            string containerName = "news-images";

            //_blobServiceClient.CreateBlobContainer(containerName);
            BlobContainerClient containerClient = _blobServiceClient
                .GetBlobContainerClient(containerName);

            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            blobClient.Upload(fileNameWithPath, true);
            return blobClient.Uri;
        }



    }
}
