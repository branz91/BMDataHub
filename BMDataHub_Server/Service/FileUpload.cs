using BMDataHub_Server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMDataHub_Server.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public FileUpload(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool DeleteFile(string fileName)
        {
            bool status = false;
            try
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "ReceiptsImages", fileName);

                if(File.Exists(path))
                {
                    File.Delete(path);
                

                    return true;
                }
                return false;
            }catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(file.Name);
                var filename = Guid.NewGuid().ToString() + fileInfo.Extension;
                var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\ReceiptsImages";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "ReceiptsImages", filename);

                var memoryStream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);

                if(!Directory.Exists(folderDirectory))
                {
                    Directory.CreateDirectory(folderDirectory);
                }
                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                memoryStream.WriteTo(fs);
                }
                var url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/";
                var fullPath = $"{url}ReceiptsImages/{filename}";
                return fullPath;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
