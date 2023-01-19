using PDM_Draxton.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PDM_Draxton.Controllers
{
    [DisableRequestSizeLimit]
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _environment;
       
        public UploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }       

        [HttpPost("upload/single")]
        public IActionResult Single(IFormFile file)
        {
            try
            {

                _ = UploadFile(file);
                return StatusCode(200);

            }catch (Exception ex){
                return StatusCode(500, ex.Message);
            }
        }

        public async Task UploadFile(IFormFile file )
        {

            var username = (HttpContext.User.Identity.Name).Substring(0, Math.Max(HttpContext.User.Identity.Name.IndexOf('@'), 0));

            if(file != null && file.Length>0)
            {
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
                string filePath = config.GetValue<string>("Parameter:urlDocumentos");
                var uploadPath = _environment.ContentRootPath + filePath + "\\" + username;

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                foreach (var archivo in Directory.GetFiles(uploadPath))
                {
                    System.IO.File.Delete(archivo);
                }
            
                var fullPath = Path.Combine(uploadPath, file.FileName);

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                    using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
        }
    }
}
