using Core3Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;

namespace Core3Test.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //IHostingEnvironment _hostingEnvironment;
        //private FileStream _fileStream;

        //public HomeController(ILogger<HomeController> logger, IHostingEnvironment hostingEnvironment, FileStream fileStream)
        //{
        //    _logger = logger;
        //    _hostingEnvironment = hostingEnvironment;
        //    _fileStream = fileStream;
        //}

        public IActionResult Index()
        {

            //string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            //IFormFile file=new FormFile()
            //{
            //    ContentType = "Ali",
            //    ContentDisposition = "Ali",
            //    Headers = new HeaderDictionary()
            //};
            //string filePath = Path.Combine(uploads, file.FileName);
            //using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            //{
            //     file.CopyToAsync(fileStream);
            //}

            return View();
        }

        [HttpPost]
        [Route("SaveFile")]
        public async Task<IActionResult> SaveFile(string text)
        {
            try
            {

                // String with whitespaces  
                string hello = " hello C# Corner has white spaces ";
                // Remove whitespaces from both ends  
                Console.WriteLine(hello.Trim());

                // String with characters  
                //string someString = text;
                char[] charsToTrim = { '*', '.' , '/', '"', '|', '<', '>', ':', '?' };
                //string cleanString = someString.Trim(charsToTrim);

                string cleanString =RemoveSpecialCharacters(text);

                //Console.WriteLine(cleanString);

                //string a = "fdsf\\ds/:* <>|?dsf d   *  <>     "; 
                //string path2 = @"C:\Users\a.ahmade\Desktop\Test2\test2";

                // char[] charsToTrim = { '*', '\\', '/', '"', '|', '<', '>', ':', '?' };
                //string b= a.Trim(charsToTrim);
                //string c = a.Trim();
                //string g = "";
                //Directory.CreateDirectory(path2);

                //string path = @"C:\Users\a.ahmade\Desktop\Test\01_Asp.NetCore_Intro.mp4";

                //string str = "";





                //Open the stream and read it back.
                //using (FileStream fs = System.IO.File.OpenRead(path))
                //{
                //    byte[] b = new byte[1024];
                //    UTF8Encoding temp = new UTF8Encoding(true);
                //    while (fs.Read(b, 0, b.Length) > 0)
                //    {
                //        str = temp.GetString(b);
                //    }

                //using (FileStream fs = System.IO.File.OpenRead(path))
                //{
                //    byte[] b = new byte[1024];
                //    UTF8Encoding temp = new UTF8Encoding(true);
                //    while (fs.Read(b, 0, b.Length) > 0)
                //    {
                //        str = temp.GetString(b);
                //    }

                //    string fName = "01_Asp.NetCore_Intro.mp4";
                //    string pathString = Path.Combine(path2, fName);
                //using (FileStream file = new FileStream(pathString, FileMode.Create))
                //{
                //System.IO.File.Copy(path, pathString);
                //FileInput.CopyTo(file);
                //    file.Close();
                //}

                //mediaBinaryStream.Close();
                //System.IO.File.Close();
                //FStream.Close();
                //fs.Close();
                //
                //}

                return Json(new
                {
                    Success = true,
                    //Message = b
                    Message = cleanString
                });
            }
            catch (Exception exception)
            {
                return Json(new
                {
                    Success = false,
                    Message = exception
                });
            }
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                /*c == '\\' || c == '/' || c == ':' || c == '*' || c == '"' || c == '<' || c == '>' || c == '|' || c == '?'*/
                if ((c ==' ') || (c == 'آ')|| (c == 'ي') || (c >= 'ا' && c <= 'ی')  || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') )
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
