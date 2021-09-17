using BlogHub.Data;
using BlogHub.Data.Models;
using BlogHub.Extensions;
using BlogHub.Managers;
using BlogHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private readonly FileManager _fileManager;
        public DataController(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _fileManager = new FileManager(context, webHostEnvironment);
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
                string uniqueFileName = _fileManager.UploadedFile(model.ArticlePicture);

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

        [HttpPost]
        public IActionResult EditArticle(EditArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var article = _context.Articles.FirstOrDefault(x => x.Id.Equals(model.Id));
                if (article is null)
                    return NotFound();

                article.Title = model.Title;
                article.Content = model.Content;

                if (model.ArticlePicture is not null)
                    article.ArticlePicture = _fileManager.UploadedFile(model.ArticlePicture);
                _context.SaveChanges();
                _fileManager.RemoveUnneccessaryFiles();
                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Home/EditArticle.cshtml", model);
        }
    }
}
