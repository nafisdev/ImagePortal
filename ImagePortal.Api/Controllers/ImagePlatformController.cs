using System.Net;
using System.Net.Http.Headers;
using ImagePortal.Api.Model;
using ImagePortal.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace ImagePortal.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagePlatformController : ControllerBase
{

    private readonly ILogger<ImagePlatformController> _logger;
    private readonly IFileService _fileService;
    private ImageStore _imageStore;

    public ImagePlatformController(ILogger<ImagePlatformController> logger, IFileService fileService,ImageStore imageStore)
    {
        _logger = logger;
        _fileService = fileService;
        _imageStore = imageStore;
    }

    [HttpPost]
    [Route("UploadImage")]
    public async Task<HttpResponseMessage> UploadImage()
    {
        try
        {
            if (Request.HasFormContentType)
            {
                var fileCollections = Request.Form.Files;
                var file = fileCollections.GetFile("ImageFile");
                string ImageName = Request.Form["ImageName"];
                var guid =Guid.NewGuid();
                Image image = new Image(){Uid= guid,
                Name= ImageName, Path= ImageName+"_"+guid.ToString()+".jpg"};
                _imageStore.Images.Add(image);
                using (Stream fileStream = file.OpenReadStream())
                {
                    await _fileService.UploadFileAsync(image.Path, fileStream);
                    await _imageStore.SaveChangesAsync();
                }
            }
        }
        catch (Exception e)
        {

        }
        return new HttpResponseMessage();

    }

    [HttpGet]
    [Route("GetImages")]
    public async Task<IList<Image>> GetImageList()
    {
        return _imageStore.Images.ToList();
    }

    [HttpGet]
    [Route("GetImage/{path}")]
    public async Task<byte[]> GetImage(string path)
    {
        // try
        {
            var fileStream = await _fileService.GetFileAsync(path);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(fileStream.ToArray());//new StreamContent(fileStream);
            // response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
            // response.StatusCode = HttpStatusCode.OK;
            // return response;
            var byteArray = fileStream.ToArray();
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(byteArray);
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("image/jpg");

            return byteArray;
            // return c;
        }
        // catch (Exception e)
        {

        }
        // return new HttpResponseMessage();

    }
}
