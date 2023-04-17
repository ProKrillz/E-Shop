namespace WebLayer.Pages.Shared.Helpers.Files
{
    public class FileHelper : IFileHelper
    {
        private readonly IWebHostEnvironment _webHost;

        public FileHelper(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }
        public async Task UploadFileAsync(IFormFile file)
        {
            string path = Path.Combine(_webHost.WebRootPath, "Image\\Card", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
        public bool DeleteFile(string fileName)
        {
            string wwwpath = _webHost.WebRootPath;

            string path = wwwpath + fileName;

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return false;
        }
    }
}
