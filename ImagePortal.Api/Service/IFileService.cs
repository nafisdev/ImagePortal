namespace ImagePortal.Api.Service
{
    public interface IFileService
    {
        Task UploadFileAsync(string imageName, Stream stream);
        Task<MemoryStream> GetFileAsync(string imageName);
    }
}