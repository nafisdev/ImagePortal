using System.Net;
using ImagePortal.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace ImagePortal.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagePlatformController : ControllerBase
{

    private readonly ILogger<ImagePlatformController> _logger;
    private readonly IFileService _fileService;

    public ImagePlatformController(ILogger<ImagePlatformController> logger, IFileService fileService)
    {
        _logger = logger;
        _fileService = fileService;
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
                var file = fileCollections.GetFile("Image");
                string ImageName = Request.Form["ImageName"];

                using (Stream fileStream = file.OpenReadStream())
                {
                    await _fileService.UploadFileAsync(ImageName, fileStream);
                }


            }

        }
        catch (Exception e)
        {

        }
        return new HttpResponseMessage();

    }

    [HttpGet]
    [Route("GetImage/{id}")]
    public async Task<HttpResponseMessage> UploadImage(Guid id)
    {
        try
        {
            var fileStream = await _fileService.GetFileAsync("Test.png");
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(fileStream);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            return response;
        }
        catch (Exception e)
        {

        }
        return new HttpResponseMessage();

    }
}
