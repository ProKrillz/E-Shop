namespace WebLayer.Pages.Shared.Helpers.Files
{
    public interface IFileHelper
    {
        Task UploadFileAsync(IFormFile file);
        bool DeleteFile(string fileName);
    }
}
