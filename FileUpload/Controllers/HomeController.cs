using FileUpload.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;

        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        public IActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Upload(FormDatacs form)
        {
            if (form.UploadedFile != null) {
                Console.WriteLine("not Uploaded");
            }            return View();
        }

    }
    }

