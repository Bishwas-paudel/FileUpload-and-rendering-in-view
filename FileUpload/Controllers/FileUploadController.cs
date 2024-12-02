using FileUpload.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

public class FileUploadController : Controller
{
    private readonly IWebHostEnvironment _environment;

    public FileUploadController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpGet]
    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(FileUploadModel model)
    {
        if (model.UploadedFile != null && model.UploadedFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder); 
            var filePath = Path.Combine(uploadsFolder, model.UploadedFile.FileName);
           
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.UploadedFile.CopyToAsync(fileStream);
            }
           using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
               
            }
            TempData["photo"] = filePath;
            ViewBag.Message = "File uploaded successfully!";
        }
        else
        {
            ViewBag.Message = "Please select a file.";
        }

        return View();
    }
}
