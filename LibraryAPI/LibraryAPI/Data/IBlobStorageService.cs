
namespace LibraryAPI.Data
{
    public interface IBlobStorageService
    {
        Task<string> UploadBlobAsync(IFormFile formFile);
        Task<bool> DeleteBlobAsync(string fileUrl);
    }
}