using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Images
{
    public class ImageUploadDTO
    {
        public IFormFile File { get; set; }
    }
}
