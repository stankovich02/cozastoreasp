using Application.DTO.Images;
using Application.Exceptions;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private static IEnumerable<string> allowedExtensions = new List<string>
        {
            ".jpg", ".jpeg", ".png"
        };

        private readonly UseCaseHandler _useCaseHandler;

        public ImagesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<ImagesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ImagesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //[Authorize]
        [HttpPost]
        public IActionResult Post([FromForm] ImageUploadDTO data)
        {
            var extension = Path.GetExtension(data.File.FileName);

            if (!allowedExtensions.Contains(extension))
            {
                return new UnsupportedMediaTypeResult();
            }

            var fileName = Guid.NewGuid().ToString() + extension;

            var savePath = Path.Combine("wwwroot", "temp", fileName);

            using var fs = new FileStream(savePath, FileMode.Create);

            data.File.CopyTo(fs);

            return StatusCode(201, new { File = fileName });
        }

        //// PUT api/<ImagesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ImagesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
