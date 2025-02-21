using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

namespace LibraryAPI.Data
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobContainerClient _blobContainerClient;

        public BlobStorageService(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("BlobStorageConnectionString");
            var containerName = config["BlobStorageContainerName"];
            _blobContainerClient = new BlobContainerClient(connectionString, containerName);
        }

        public async Task<string> UploadBlobAsync(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
            {
                throw new ArgumentException("Invalid file.");
            }

            string fileName = $"{Guid.NewGuid()}_{formFile.FileName}";
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);

            await using (var stream = formFile.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = formFile.ContentType });
            }

            return blobClient.Uri.ToString();
        }

        public async Task<bool> DeleteBlobAsync(string fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl))
                return false;

            var blobName = new Uri(fileUrl).Segments.Last();
            var blobClient = _blobContainerClient.GetBlobClient(blobName);

            return await blobClient.DeleteIfExistsAsync();
        }
    }
}
