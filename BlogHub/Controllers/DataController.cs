using BlogHub.Data;
using BlogHub.Data.Models;
using BlogHub.Extensions;
using BlogHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace BlogHub.Controllers
{
    // Article'larla ilgili ekleme silme ve güncelleme işlemlerini buradan yapıcam.
    [Authorize]
    public class DataController : Controller
    {
        readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DataController(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddArticle(AddArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Article article = new Article
                {
                    Title = model.Title,
                    Content = model.Content,
                    AuthorId = User.GetID(),
                    ArticlePicture = uniqueFileName,
                };
                _context.Articles.Add(article);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Home/AddArticle.cshtml");
        }


        private string UploadedFile(AddArticleViewModel model)
        {
            string uniqueFileName = null;

            if (model.ArticlePicture != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ArticlePicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ArticlePicture.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
