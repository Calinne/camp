using Microsoft.AspNetCore.Mvc;
using campairbnb.Data;
using campairbnb.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace campairbnb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly ICampAirbnbDataContext _context;

        public ImagesController(ICampAirbnbDataContext context)
        {
            _context = context;
        }

        [HttpPost("upload/{campingSpotId}")]
        public ActionResult UploadImage(int campingSpotId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var image = new Image
                {
                    CampingSpotId = campingSpotId,
                    ImageName = file.FileName,
                    ImageData = ms.ToArray()
                };
                _context.AddImage(image);
            }
            return Ok();
        }

        [HttpGet("{campingSpotId}")]
        public ActionResult<IEnumerable<Image>> GetImages(int campingSpotId)
        {
            var images = _context.GetImages(campingSpotId);
            if (images == null)
            {
                return NotFound();
            }
            return Ok(images);
        }
    }
}
