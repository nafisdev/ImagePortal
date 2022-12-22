namespace ImagePortal.Api.Service
{
    public class FileService : IFileService
    {

        public FileService()
        {}
        public async Task UploadFileAsync(string imageName, Stream stream)
        {
            string folderName = "Upload";
            DirectoryInfo info = new DirectoryInfo(folderName);
            if (!info.Exists)
            {
                info.Create();
            }
            using (FileStream outputFileStream = new FileStream(Path.Combine(folderName,imageName), FileMode.Create))
            {
                stream.CopyTo(outputFileStream);
            }

        }

        public async Task<MemoryStream> GetFileAsync(string imageName)
        {
            string folderName = "Upload";
            using (FileStream outputFileStream = new FileStream(Path.Combine(folderName,imageName), FileMode.Open))
            {
                var memoryStream = new MemoryStream();
                await outputFileStream.CopyToAsync(memoryStream);
                return memoryStream;
            }

        }
    }
}