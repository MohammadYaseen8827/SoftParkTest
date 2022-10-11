using Platform.Blazor.Interfaces;

namespace Platform.Blazor.Services
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _env;
        public FileUpload(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void RemoveFile(string picName)
        {
            var path = $"{_env.WebRootPath}\\uploads\\{picName}";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public async Task UploadFile(Stream msFile, string picName)
        {
            var path = $"{_env.WebRootPath}\\uploads\\{picName}";
            var buffer = new byte[4 * 1096];
            int bytesRead;
            double totalRead = 0;
            using FileStream fs = new FileStream(path, FileMode.Create);

            while ((bytesRead = await msFile.ReadAsync(buffer)) != 0)
            {
                totalRead += bytesRead;
                await fs.WriteAsync(buffer);
            }

        }
    }
}
