using ToplearnBlogProject.Shared.Dto.Global;

namespace ToplearnBlogProject.Api.Services
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IWebHostEnvironment _env;
        public UploadFileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string Save(FileDto file, string folderName)
        {
            string fileName = $"{Guid.NewGuid()}.{file.Extension}";
            string directory = Path.Combine(_env.WebRootPath, folderName);
            string path = Path.Combine(directory, fileName);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllBytesAsync(path , file.Bytes).GetAwaiter();

            return fileName;
        }
        public void Delete(string fileName , string folderName)
        {
            var current = Path.GetFileName(fileName);
            string address = Path.Combine(_env.WebRootPath , folderName , current);

            if (File.Exists(address))
            {
                File.Delete(address);
            }
        }
    }

    public interface IUploadFileService
    {
        void Delete(string fileName, string folderName);
        string Save(FileDto file, string folderName);
    }
}
