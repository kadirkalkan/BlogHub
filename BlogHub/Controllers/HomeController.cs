using BlogHub.Data;
using BlogHub.Data.Models;
using BlogHub.Extensions;
using BlogHub.Managers;
using BlogHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly FileManager _fileManager;
        public HomeController(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _fileManager = new FileManager(context, webHostEnvironment);
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
                        AuthorId = x.AuthorId,
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
            var article = _context.Articles.FirstOrDefault(x => x.Id.Equals(id));

            // Bu id'ye ait Article Var Fakat Login Olan Kullanıcıya Ait Değil.
            if (article is not null && !User.IsThisUserLoggedOne(article.AuthorId))
                article = null;

            if (article is null)
                return NotFound();

            EditArticleViewModel model =  new EditArticleViewModel() 
            { 
                Id = article.Id, 
                Title = article.Title, 
                Content = article.Content, 
                ArticlePictureName = _fileManager.GetImageName(article.ArticlePicture)
            };

            return View(model);
        }

        [HttpGet("[action]/{username}")]
        public IActionResult Profile(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName.Equals(username));

            if (user is null)
                return NotFound();

            List<ArticleListViewModel> articleList = _context.Articles
            .OrderByDescending(x => x.CreatedTime)
            .Include(x => x.Author)
            .Where(x=>x.AuthorId.Equals(user.Id))
            .AsEnumerable()// DBSet Lokalde değişik bir mimariye sahip olduğundan Çok Satırlı Lambda Kullanımına İzin Vermiyor. Bu Yüzden Yapıyı Enumerable'a çevirmek Gerekiyor.
            .Select(x =>
            {
                return new ArticleListViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    AuthorId = x.AuthorId,
                    Author = x.Author.FullName,
                    ArticlePicture = (string.IsNullOrEmpty(x.ArticlePicture) ? "null.png" : x.ArticlePicture),
                    CreatedTime = x.CreatedTime
                };
            })
            .ToList();

            return View(articleList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
