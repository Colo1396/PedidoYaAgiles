using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace PedidoYa.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestImageFile : ControllerBase
    {
        [HttpPost]
        public string SaveImage([FromBody]string base64) {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "test"); //carpeta donde se guarda el archivo
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath); //crear carpeta si no existe
            string fileName = DateTime.Now.ToString("yyyy-MM-dd-T-HH-mm-ss", DateTimeFormatInfo.InvariantInfo);
            System.IO.File.WriteAllBytes(Path.Combine(folderPath,fileName)+".png", Convert.FromBase64String(base64));
            return Path.Combine(folderPath, fileName) + ".png";
        }
    }
}
