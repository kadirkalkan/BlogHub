using BlogHub.Data;
using BlogHub.Data.Models;
using BlogHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogHub.Controllers
{
    // Anasayfa, Profil Sayfası Üzerindeki İşlemleri Content Controller Üzerinden Yöneteceğim
    /* 
     * Ekstra Bilgi : Neden Extension Method Kullanmalıyız.
     * 
     * Extension Method'ların kullanımı ile kodumuz daha temiz ve okunaklı hale getirilebilir ve angarya işten kurtulabiliriz.

              var article = _context.Articles.FirstOrDefault(x => User.FindFirst(ClaimTypes.NameIdentifier).Value.Equals(x.AuthorId));
                  article = _context.Articles.FirstOrDefault(x => User.GetID().Equals(x.AuthorId));
                  article = _context.Articles.FirstOrDefault(x => User.IsThisUserLoggedOne(x.AuthorId));
          */
    [Authorize]
    public class HomeController : Controller
    {
        readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ArticleListViewModel> articleList = _context.Articles
                .OrderByDescending(x => x.CreatedTime)
                .Take(20)
                .Include(x=> x.Author)
                .AsEnumerable()// DBSet Lokalde değişik bir mimariye sahip olduğundan Çok Satırlı Lambda Kullanımına İzin Vermiyor. Bu Yüzden Yapıyı Enumerable'a çevirmek Gerekiyor.
                .Select(x => 
                {
                    return new ArticleListViewModel()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Content = x.Content,
                        Author = x.Author.FullName,
                        ArticlePicture = (string.IsNullOrEmpty(x.ArticlePicture) ? "null.png" : x.ArticlePicture),
                        CreatedTime = x.CreatedTime
                    };
                })
                .ToList();

            return View(articleList);
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }
        

        [HttpGet]
        public IActionResult EditArticle(int id)
        {
            EditArticleViewModel model = _context.Articles.Select(x => new EditArticleViewModel() { Id = x.Id, Title = x.Title, Content = x.Content, ArticlePictureName = GetImageName(x.ArticlePicture)}).FirstOrDefault(x => x.Id.Equals(id));
            return View(model);
        }

        private static string GetImageName(string imageName)
        {
            string name = "Choose File";
            if (!string.IsNullOrEmpty(imageName))
            {
                //93b56cb5-1bbc-4211-a640-40135d82e885_dosyaismi.jpg
                // _'den itibaren uniqueFileName içerisindeki dosya adını ve uzantısını alır.
                name = imageName.Substring(37);
            }
            return name;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
