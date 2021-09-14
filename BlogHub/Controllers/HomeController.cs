using BlogHub.Data;
using BlogHub.Data.Models;
using BlogHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                .OrderByDescending(x=>x.CreatedTime)
                .Take(20)
                .Select(x=> new ArticleListViewModel() { Id = x.Id, Title = x.Title, Content = x.Content, Author = x.Author.FullName, CreatedTime = x.CreatedTime })
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
