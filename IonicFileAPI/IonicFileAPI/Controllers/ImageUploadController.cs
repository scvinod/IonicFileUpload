using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IonicFileAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ImageUpload")]
    public class ImageUploadController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImageUploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(HttpRequestMessage msg)
        {
            try
            {
                IFormFileCollection files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string contentPath = _hostingEnvironment.ContentRootPath;

                    foreach (var formFile in files)
                    {
                        if (formFile.Length > 0)
                        {
                            var filePath = Path.Combine(contentPath, "UploadedImages", formFile.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await formFile.CopyToAsync(stream);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return Ok();
        }
    }
}