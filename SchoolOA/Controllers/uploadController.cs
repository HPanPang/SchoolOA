using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using OABackground.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolOA
{
    
    [Route("api/[controller]")]
    public class UpLoadController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public FileService FileService = new FileService();
        public UpLoadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        public string Post([FromForm] IFormCollection formCollection)
        {

            var getCookie = "";
            HttpContext.Request.Cookies.TryGetValue("getCookie", out getCookie);
            string result = "";
            string webRootPath = "C://文稿";
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            String Tpath = "/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";
            string FilePath = webRootPath + Tpath;
            FormFileCollection filelist = (FormFileCollection)formCollection.Files;
            foreach (IFormFile file in filelist)
            {

                string name = file.FileName;
                string FileName = file.FileName;
                string type = System.IO.Path.GetExtension(name);
                DirectoryInfo di = new DirectoryInfo(FilePath);
                if (!di.Exists) { di.Create(); }
                using (FileStream fs = System.IO.File.Create(FilePath + FileName))
                {
                    // 复制文件
                    file.CopyTo(fs);
                    // 清空缓冲区数据
                    fs.Flush();
                    FileService.upload(FilePath, FileName, "胡佳俊","无");
                }
                result = "0";
            }
            return "{\"msg\":" + "\"\"," + "\"code\":" + result + "}";

        }
    }
}
